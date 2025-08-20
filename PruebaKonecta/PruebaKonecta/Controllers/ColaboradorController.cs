using System;
using System.Web.Http;
using PruebaKonecta.Core;
using PruebaKonecta.Data;

namespace PruebaKonecta.API.Controllers
{
    [RoutePrefix("api/colaborador")]
    public class ColaboradorController : ApiController
    {
        private ColaboradorRepository repo = new ColaboradorRepository();

        [HttpPost]
        [Route("registrar")]
        public IHttpActionResult RegistrarColaborador([FromBody] Colaborador colaborador)
        {
            if (colaborador == null) return BadRequest("Colaborador vacío.");
            if (!colaborador.TieneCamposObligatorios()) return BadRequest("Faltan campos obligatorios.");
            if (!colaborador.EsSalarioValido()) return BadRequest("El salario debe ser mayor a 0.");
            if (!colaborador.EsEmailValido()) return BadRequest("Correo inválido.");

            string resultado = repo.RegistrarColaborador(colaborador);
            if (resultado.StartsWith("Error")) return InternalServerError(new Exception(resultado));

            return Ok(resultado);
        }

        [HttpGet]
        [Route("consultar/{numeroIdentificacion}")]
        public IHttpActionResult ConsultarColaboradorPorIdentificacion(string numeroIdentificacion)
        {
            var colaborador = repo.ConsultarColaboradorPorIdentificacion(numeroIdentificacion);
            if (colaborador == null) return NotFound();
            return Ok(colaborador);
        }
    }
}
