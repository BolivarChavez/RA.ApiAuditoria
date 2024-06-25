using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonedasController : Controller
    {
        private readonly IMonedasRepository _repository;
        public MonedasController(IMonedasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserta un nuevo registro de la tabla de monedas 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// mo_codigo : Codigo de la moneda <br />
        /// mo_descripcion : Nombre o descripcion de la moneda <br />
        /// mo_estado : Indica si la moneda esta Activa (A), Inactiva (I) o Eliminada (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoMonedas
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Monedas monedas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(monedas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro de la tabla de monedas 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// mo_codigo : Codigo de la moneda <br />
        /// mo_descripcion : Nombre o descripcion de la moneda <br />
        /// mo_estado : Indica si la moneda esta Activa (A), Inactiva (I) o Eliminada (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaMonedas
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Monedas monedas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(monedas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros de la tabla de monedas 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo de la moneda <br /><br />
        /// Procedimiento almacenado : api_ConsultaMonedas
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Monedas> Get(int codigo)
        {
            List<Monedas> list_monedas;
            string JSONString = string.Empty;

            list_monedas = _repository.Consulta(codigo).ToList();
            return list_monedas;
        }
    }
}
