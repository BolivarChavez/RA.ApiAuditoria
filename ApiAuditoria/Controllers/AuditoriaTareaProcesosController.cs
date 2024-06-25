using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaTareaProcesosController : Controller
    {
        private readonly IAuditoriaTareaProcesosRepository _repository;
        public AuditoriaTareaProcesosController(IAuditoriaTareaProcesosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un nuevo proceso asociado a una tarea de una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// at_empresa : Codigo de la empresa <br />
        /// at_auditoria : Codigo de la auditoria <br />
        /// at_tarea : Codigo de la tarea <br />
        /// at_secuencia : Secuencia del proceso relacionado a la tarea <br /> 
        /// at_auditor : Codigo del auditor <br />
        /// at_responsable : Codigo del responsable <br />
        /// at_fecha : Fecha de registro del proceso <br />
        /// at_observaciones : Observaciones o anotaciones relacionadas a la tarea <br />
        /// at_estado : Estado del proceso de la tarea Activa (A), Inactiva (I), Eliminada (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaTareaProcesos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaTareaProcesos auditoriaTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(auditoriaTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro de proceso asociado a una tarea de una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// at_empresa : Codigo de la empresa <br />
        /// at_auditoria : Codigo de la auditoria <br />
        /// at_tarea : Codigo de la tarea <br />
        /// at_secuencia : Secuencia del proceso relacionado a la tarea <br />
        /// at_auditor : Codigo del auditor <br />
        /// at_responsable : Codigo del responsable <br />
        /// at_fecha : Fecha de registro del proceso <br />
        /// at_observaciones : Observaciones o anotaciones relacionadas a la tarea <br />
        /// at_estado : Estado del proceso de la tarea Activa (A), Inactiva (I), Eliminada (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaTareaProcesos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaTareaProcesos auditoriaTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(auditoriaTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los procesos asociados a una tarea de una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria <br /><br />
        /// tarea : Codigo de la tarea
        /// Procedimiento almacenado : api_ConsultaAuditoriaTareaProcesos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}")]
        public IEnumerable<AuditoriaTareaProcesos> Get(int empresa, int auditoria, int tarea)
        {
            List<AuditoriaTareaProcesos> list_auditoria_tarea_procesos;
            string JSONString = string.Empty;

            list_auditoria_tarea_procesos = _repository.Consulta(empresa, auditoria, tarea).ToList();
            return list_auditoria_tarea_procesos;
        }
    }
}
