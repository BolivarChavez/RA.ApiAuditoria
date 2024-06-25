using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaAsignacionController : Controller
    {
        private readonly IAuditoriaAsignacionRepository _repository;
        public AuditoriaAsignacionController(IAuditoriaAsignacionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asigna un responsable a una tarea relacionada a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// aa_empresa : Codigo de la empresa <br />
        /// aa_auditoria : Codigo de la auditoria <br />
        /// aa_tarea : Codigo de la tarea asignada a la auditoria <br />
        /// aa_secuencia : Secuencia de asignacion de tarea <br />
        /// aa_responsable : Codigo del responsable asignado a la tarea <br />
        /// aa_tipo : Tipo de responsable. Responsable de Aduitoria (R), Conocimiento de proceso (P), Capacitacion (C) <br />
        /// aa_rol : Para aquellos que son responsables, indica si es Auditor (A) o Supervisor o Jefe (J) <br />
        /// aa_estado : Indica si el registro esta Activo (A), Inactivo (I) o Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaAsignacion
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaAsignacion auditoriaAsignacion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(auditoriaAsignacion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza una tarea de auditoria que ha sido previamente asignada a un responsable
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// aa_empresa : Codigo de la empresa <br />
        /// aa_auditoria : Codigo de la auditoria <br />
        /// aa_tarea : Codigo de la tarea asignada a la auditoria <br />
        /// aa_secuencia : Secuencia de asignacion de tarea <br />
        /// aa_responsable : Codigo del responsable asignado a la tarea <br />
        /// aa_tipo : Tipo de responsable. Responsable de Aduitoria (R), Conocimiento de proceso (P), Capacitacion (C) <br />
        /// aa_rol : Para aquellos que son responsables, indica si es Auditor (A) o Supervisor o Jefe (J) <br />
        /// aa_estado : Indica si el registro esta Activo (A), Inactivo (I) o Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaAsignacion
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaAsignacion auditoriaAsignacion)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(auditoriaAsignacion).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los responsables asignados a una tarea relacionada a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria <br />
        /// tarea : Codigo de la tarea asignada a la auditoria <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditoriaAsignacion
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}")]
        public IEnumerable<AuditoriaAsignacion> Get(int empresa, int auditoria, int tarea)
        {
            List<AuditoriaAsignacion> list_auditoria_asignacion;
            string JSONString = string.Empty;

            list_auditoria_asignacion = _repository.Consulta(empresa, auditoria, tarea).ToList();
            return list_auditoria_asignacion;
        }
    }
}
