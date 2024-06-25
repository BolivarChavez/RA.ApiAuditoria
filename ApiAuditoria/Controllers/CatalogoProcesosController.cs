using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoProcesosController : Controller
    {
        private readonly ICatalogoProcesosRepository _repository;
        public CatalogoProcesosController(ICatalogoProcesosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un nuevo registro del catalogo de procesos asociados a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cp_empresa : Codigo de empresa <br />
        /// cp_codigo : Codigo del tipo de proceso de auditoria <br />
        /// cp_descripcion : Nombre o descripcion del proceso de auditoria <br />
        /// cp_estado : Indica si el registro es Activo (A) o Inactivo (I) o Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoCatalogoProcesos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoProcesos catalogoProcesos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoProcesos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro del catalogo de procesos asociados a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cp_empresa : Codigo de empresa <br />
        /// cp_codigo : Codigo del tipo de proceso de auditoria <br />
        /// cp_descripcion : Nombre o descripcion del proceso de auditoria <br />
        /// cp_estado : Indica si el registro es Activo (A) o Inactivo (I) o Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaCatalogoProcesos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoProcesos catalogoProcesos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoProcesos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros del catalogo de procesos asociados a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaCatalogoProcesos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoProcesos> Get(int empresa)
        {
            List<CatalogoProcesos> list_catalogo_procesos;
            string JSONString = string.Empty;

            list_catalogo_procesos = _repository.Consulta(empresa).ToList();
            return list_catalogo_procesos;
        }
    }
}
