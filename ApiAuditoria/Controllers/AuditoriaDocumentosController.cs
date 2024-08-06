using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaDocumentosController : Controller
    {
        private readonly IAuditoriaDocumentosRepository _repository;
        public AuditoriaDocumentosController(IAuditoriaDocumentosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa el contenido de un registro de plantilla (cheque, transferencia, etc.) 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ad_empresa : Codigo de la empresa <br />
        /// ad_auditoria : Codigo de la auditoria <br />
        /// ad_tarea : Codigo de la Tarea <br />
        /// ad_codigo : Codigo del documento registrado <br />
        /// ad_plantilla : Codigo de la plantilla relacionada al documento <br />
        /// ad_referencia : Referencia de registro de ingreso individual o por plantilla <br />
        /// ad_registro : Detalle del registro de documento <br />
        /// ad_auditoria_origen : Codigo de auditoria origen desde la cual proviene el registro <br />
        /// ad_responsable : Responsable principal de registro y revision de la informacion <br />
        /// ad_estado : Estado del registro, indica si esta Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaDocumentos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaDocumentos auditoriaDocumento)
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
        /// Actualiza el contenido de un registro de plantilla (cheque, transferencia, etc.)
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ad_empresa : Codigo de la empresa <br />
        /// ad_auditoria : Codigo de la auditoria <br />
        /// ad_tarea : Codigo de la Tarea <br />
        /// ad_codigo : Codigo del documento registrado <br />
        /// ad_plantilla : Codigo de la plantilla relacionada al documento <br />
        /// ad_referencia : Referencia de registro de ingreso individual o por plantilla <br />
        /// ad_registro : Detalle del registro de documento <br />
        /// ad_auditoria_origen : Codigo de auditoria origen desde la cual proviene el registro <br />
        /// ad_responsable : Responsable principal de registro y revision de la informacion <br />
        /// ad_estado : Estado del registro, indica si esta Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaDocumentos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaDocumentos auditoriaDocumento)
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
        /// Consulta todas las lineas de una plantilla ingresada (cheque, transferencia, etc.) 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria <br />
        /// tarea : Codigo de la Tarea <br /><br />
        /// plantilla : Codigo de la plantilla relacionada al documento
        /// anio : Año de consulta de la auditoria. Cero (0) para todos los años
        /// Procedimiento almacenado : api_ConsultaAuditoriaDocumentos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}/{plantilla}/{anio}")]
        public IEnumerable<AuditoriaDocumentos> Get(int empresa, int auditoria, int tarea, int plantilla, int anio)
        {
            List<AuditoriaDocumentos> list_auditoria_documento;
            string JSONString = string.Empty;

            list_auditoria_documento = _repository.Consulta(empresa, auditoria, tarea, plantilla, anio).ToList();
            return list_auditoria_documento;
        }
    }
}
