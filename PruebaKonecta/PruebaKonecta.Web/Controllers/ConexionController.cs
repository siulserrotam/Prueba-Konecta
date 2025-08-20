using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaKonecta.Web.Controllers
{
    public class ConexionController : Controller
    {
        private readonly HttpClient _httpClient;

        public ConexionController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://localhost:44385/"); // URL de la API
        }

        public async Task<ActionResult> Probar()
        {
            var response = await _httpClient.GetAsync("api/test/conexion");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                ViewBag.Mensaje = resultado;
            }
            else
            {
                ViewBag.Mensaje = "Error al conectar con la API";
            }

            return View();
        }
    }
}
