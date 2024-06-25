using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoTareasController : Controller
    {
        private readonly ICatalogoTareasRepository _repository;
        public CatalogoTareasController(ICatalogoTareasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserta un nuevo registro del catalogo de tareas asociadas a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ct_empresa : Codigo de la empresa <br />
        /// ct_proceso : Codigo de proceso de auditoria <br />
        /// ct_codigo : Codigo de tarea asociada a un proceso de auditoria <br />
        /// ct_descripcion : Nombre o descripcion de la tarea relacionada al proceso de auditoria <br />
        /// ct_estado : Estado del registro (A) Activo, (I) Inactivo, (X) Eliminado <br /><br />
        /// Procedimiento almacenado : api_IngresoCatalogoTareas
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoTareas catalogoTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro del catalogo de tareas asociadas a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ct_empresa : Codigo de la empresa <br />
        /// ct_proceso : Codigo de proceso de auditoria <br />
        /// ct_codigo : Codigo de tarea asociada a un proceso de auditoria <br />
        /// ct_descripcion : Nombre o descripcion de la tarea relacionada al proceso de auditoria <br />
        /// ct_estado : Estado del registro (A) Activo, (I) Inactivo, (X) Eliminado <br /><br />
        /// Procedimiento almacenado : api_ActualizaCatalogoTareas
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoTareas catalogoTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros del catalogo de tareas asociadas a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaCatalogoTareas
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoTareas> Get(int empresa)
        {
            List<CatalogoTareas> list_catalogo_tareas;
            string JSONString = string.Empty;

            list_catalogo_tareas = _repository.Consulta(empresa).ToList();
            return list_catalogo_tareas;
        }
    }
}
