using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoGastosController : Controller
    {
        private readonly ICatalogoGastosRepository _repository;
        public CatalogoGastosController(ICatalogoGastosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserta un nuevo registro del catalogo de gastos relacionados a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cg_empresa : Codigo de empresa <br />
        /// cg_codigo : Codigo de tipo de gasto <br />
        /// cg_descripion : Descripcion del tipo de gasto <br />
        /// cg_estado : Estado de registro de tipo de gasto Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoCatalogoGastos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoGastos catalogoGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro del catalogo de gastos relacionados a auditorias
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cg_empresa : Codigo de empresa <br />
        /// cg_codigo : Codigo de tipo de gasto <br />
        /// cg_descripion : Descripcion del tipo de gasto <br />
        /// cg_estado : Estado de registro de tipo de gasto Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaCatalogoGastos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoGastos catalogoGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro del catalogo de gastos relacionados a auditorias
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaCatalogoGastos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoGastos> Get(int empresa)
        {
            List<CatalogoGastos> list_catalogo_gastos;
            string JSONString = string.Empty;

            list_catalogo_gastos = _repository.Consulta(empresa).ToList();
            return list_catalogo_gastos;
        }
    }
}
