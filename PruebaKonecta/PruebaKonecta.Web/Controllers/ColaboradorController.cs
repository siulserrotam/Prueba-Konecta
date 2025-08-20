using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using PruebaKonecta.Core;

namespace PruebaKonecta.Web.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly string apiBase = "https://localhost:44385/";

        public ActionResult Registrar() => View();

        [HttpPost]
        public ActionResult Registrar(Colaborador model)
        {
            if (!model.TieneCamposObligatorios())
            {
                ViewBag.Mensaje = "Error: Faltan campos obligatorios.";
                return View();
            }
            if (!model.EsSalarioValido())
            {
                ViewBag.Mensaje = "Error: Salario debe ser mayor a 0.";
                return View();
            }
            if (!model.EsEmailValido())
            {
                ViewBag.Mensaje = "Error: Email inválido.";
                return View();
            }

            string mensaje;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBase);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync("api/colaborador/registrar", content).Result;

                    if (response.IsSuccessStatusCode)
                        mensaje = response.Content.ReadAsStringAsync().Result;
                    else
                        mensaje = $"Error API: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar: " + ex.Message;
            }

            ViewBag.Mensaje = mensaje;
            return View();
        }

        public ActionResult Consultar() => View();

        [HttpPost]
        public ActionResult Consultar(string numeroIdentificacion)
        {
            if (string.IsNullOrWhiteSpace(numeroIdentificacion))
            {
                ViewBag.Error = "Debe ingresar un número de identificación.";
                return View();
            }

            Colaborador colaborador = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBase);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync($"api/colaborador/consultar/{numeroIdentificacion}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        colaborador = JsonConvert.DeserializeObject<Colaborador>(jsonString);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Error = "Colaborador no encontrado.";
                    }
                    else
                    {
                        ViewBag.Error = $"Error API: {response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al consultar: " + ex.Message;
            }

            return View(colaborador);
        }
    }
}
