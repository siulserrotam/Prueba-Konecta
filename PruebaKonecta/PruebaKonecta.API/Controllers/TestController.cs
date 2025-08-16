using System;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace PruebaKonecta.API.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("conexion")]
        public IHttpActionResult ProbarConexion()
        {
            // Tomamos la cadena de conexión desde Web.config
            string cadena = ConfigurationManager.ConnectionStrings["CadenaSQL"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    con.Open(); // Intentamos abrir la conexión
                }

                return Ok("¡Conexión a la base de datos exitosa!");
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex); // Devuelve el error si falla
            }
        }
    }
}
