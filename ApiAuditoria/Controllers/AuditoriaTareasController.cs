using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaTareasController : Controller
    {
        private readonly IAuditoriaTareasRepository _repository;
        public AuditoriaTareasController(IAuditoriaTareasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un nuevo proceso asociado a una tarea de una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// at_empresa : Codigo de empresa <br />
        /// at_auditoria : Codigo o numero de auditoria <br />
        /// at_tarea : Codigo de tarea asociada a la auditoria <br />
        /// at_oficina : Oficina en la cual se realiza la auditoria <br />
        /// at_asignacion : Detalle de asignaciones <br />
        /// at_estado : Indica si la tarea esta Abierta (A), En proceso (P), Cerrada (C) o Anulada (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaTareas
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaTareas auditoriaTareas)
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
        /// Actualiza un registro de asignacion de tarea a auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// at_empresa : Codigo de empresa <br />
        /// at_auditoria : Codigo o numero de auditoria <br />
        /// at_tarea : Codigo de tarea asociada a la auditoria <br />
        /// at_oficina : Oficina en la cual se realiza la auditoria <br />
        /// at_asignacion : Detalle de asignaciones <br />
        /// at_estado : Indica si la tarea esta Abierta (A), En proceso (P), Cerrada (C) o Anulada (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaTareas
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaTareas auditoriaTareas)
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
        /// Consulta de tareas asociadas a una auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de empresa <br />
        /// auditoria : Codigo o numero de auditoria <br />
        /// tarea : Codigo de tarea asociada a la auditoria <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditoriaTareas
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}")]
        public IEnumerable<AuditoriaTareas> Get(int empresa, int auditoria, int tarea)
        {
            List<AuditoriaTareas> list_auditoria_tareas;
            string JSONString = string.Empty;

            list_auditoria_tareas = _repository.Consulta(empresa, auditoria, tarea).ToList();
            return list_auditoria_tareas;
        }
    }
}
