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

        /// <summary>
        /// Inserta un nuevo registro de la tabla de cotizaciones 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// co_empresa : Codigo de la empresa <br />
        /// co_moneda_base : Codigo de la moneda base de la cotizacion <br />
        /// co_moneda_destino : Codigo de la moneda de referencia para la cotizacion <br />
        /// co_cotizacion : Valor de cotizacion hacia la moneda destino <br />
        /// co_fecha_vigencia : Fecha a partir de la cual la cotizacion esta vigente <br />
        /// co_estado : Indica si el registro esta Activo (A) o Inactivo (I) <br /><br />
        /// Procedimiento almacenado : api_IngresoCotizaciones
        /// </remarks>
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

        /// <summary>
        /// Actualiza un registro de la tabla de cotizaciones
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// co_empresa : Codigo de la empresa <br />
        /// co_moneda_base : Codigo de la moneda base de la cotizacion <br />
        /// co_moneda_destino : Codigo de la moneda de referencia para la cotizacion <br />
        /// co_cotizacion : Valor de cotizacion hacia la moneda destino <br />
        /// co_fecha_vigencia : Fecha a partir de la cual la cotizacion esta vigente <br />
        /// co_estado : Indica si el registro esta Activo (A) o Inactivo (I) <br /><br />
        /// Procedimiento almacenado : api_ActualizaCotizaciones
        /// </remarks>
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

        /// <summary>
        /// Consulta los registros de la tabla de cotizaciones para una combinacion de monedas
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// monedaBase : Codigo de la moneda base de la cotizacion <br />
        /// monedaDestino : Codigo de la moneda de referencia para la cotizacion <br />
        /// anio : Año de referencia para la consulta <br /><br />
        /// Procedimiento almacenado : api_ConsultaCotizaciones
        /// </remarks>
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
