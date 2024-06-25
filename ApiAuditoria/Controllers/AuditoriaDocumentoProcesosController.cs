using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaDocumentoProcesosController : Controller
    {
        private readonly IAuditoriaDocumentoProcesosRepository _repository;
        public AuditoriaDocumentoProcesosController(IAuditoriaDocumentoProcesosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un nuevo proceso de un documento que pertenece a una tarea relacionada a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ad_empresa : Codigo de la empresa <br />
        /// ad_auditoria : Codigo de la auditoria <br />
        /// ad_tarea : Codigo de la tarea <br />
        /// ad_codigo : Codigo del documento <br />
        /// ad_secuencia : Secuencia de proceso del documento <br />
        /// ad_fecha : Fecha de registro del proceso <br />
        /// ad_auditor : Codigo de auditor <br />
        /// ad_responsable : Codigo de responsable <br />
        /// ad_observaciones : Observaciones o comentarios relacionados al proceso del documento <br />
        /// ad_documento : Referencia a documentos de soporte <br />
        /// ad_estado : Estado del proceso del documentos Activo (A), Inactivo (I), Eliminado (X), Cerrado (C), En Espera (E) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaDocumentoProcesos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaDocumentoProcesos auditoriaDocumento)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(auditoriaDocumento).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un proceso de un documento que pertenece a una tarea relacionada a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ad_empresa : Codigo de la empresa <br />
        /// ad_auditoria : Codigo de la auditoria <br />
        /// ad_tarea : Codigo de la tarea <br />
        /// ad_codigo : Codigo del documento <br />
        /// ad_secuencia : Secuencia de proceso del documento <br />
        /// ad_fecha : Fecha de registro del proceso <br />
        /// ad_auditor : Codigo de auditor <br />
        /// ad_responsable : Codigo de responsable <br />
        /// ad_observaciones : Observaciones o comentarios relacionados al proceso del documento <br />
        /// ad_documento : Referencia a documentos de soporte <br />
        /// ad_estado : Estado del proceso del documentos Activo (A), Inactivo (I), Eliminado (X), Cerrado (C), En Espera (E) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaDocumentoProcesos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaDocumentoProcesos auditoriaDocumento)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(auditoriaDocumento).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los procesos de un documento que pertenece a una tarea relacionada a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria <br />
        /// tarea : Codigo de la tarea <br />
        /// codigo : Codigo del documento <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditoriaDocumentoProcesos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}/{codigo}")]
        public IEnumerable<AuditoriaDocumentoProcesos> Get(int empresa, int auditoria, int tarea, int codigo)
        {
            List<AuditoriaDocumentoProcesos> list_auditoria_documento_procesos;
            string JSONString = string.Empty;

            list_auditoria_documento_procesos = _repository.Consulta(empresa, auditoria, tarea, codigo).ToList();
            return list_auditoria_documento_procesos;
        }
    }
}
