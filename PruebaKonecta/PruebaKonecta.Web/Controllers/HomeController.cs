using System;
using System.Net.Http;
using System.Web.Mvc;

namespace PruebaKonecta.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Acción temporal para probar conexión API
        public ActionResult ProbarConexionAPI()
        {
            string mensaje;

            try
            {
                using (var client = new HttpClient())
                {
                    // Puerto de la API: 44361
                    client.BaseAddress = new Uri("https://localhost:44361/");
                    var response = client.GetAsync("api/test/conexion").Result;
                    mensaje = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al conectarse a la API: " + ex.Message;
            }

            return Content(mensaje); // Muestra el mensaje directamente en el navegador
        }
    }
}
