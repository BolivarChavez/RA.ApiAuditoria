using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CotizacionesController : Controller
    {
        private readonly ICotizacionesRepository _repository;
        public CotizacionesController(ICotizacionesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Cotizaciones cotizaciones)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(cotizaciones).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Cotizaciones cotizaciones)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(cotizaciones).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpGet]
        [Route("Consulta/{empresa}/{monedaBase}/{monedaDestino}/{anio}")]
        public IEnumerable<Cotizaciones> Get(int empresa, int monedaBase, int monedaDestino, int anio)
        {
            List<Cotizaciones> list_cotizaciones;
            string JSONString = string.Empty;

            list_cotizaciones = _repository.Consulta(empresa, monedaBase, monedaDestino, anio).ToList();
            return list_cotizaciones;
        }
    }
}
