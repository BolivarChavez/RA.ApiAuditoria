using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriasController : Controller
    {
        private readonly IAuditoriasRepository _repository;
        public AuditoriasController(IAuditoriasRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un nuevo registro de auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// au_empresa : Codigo de la empresa <br />
        /// au_codigo : Codigo de proceso de auditoria. Cero (0) para un nuevo registro. <br />
        /// au_oficina_origen : Oficina desde la cual se origina la auditoria <br />
        /// au_oficina_destino : Oficina objeto de la auditoria <br />
        /// au_tipo_proceso : Tipo de proceso de auditoria <br />
        /// au_fecha_inicio : Fecha de inicio de la auditoria <br />
        /// au_fecha_cierre : Fecha de cierre de auditoria <br />
        /// au_tipo : Tipo de auditoria Local (L) o Remota (R) <br />
        /// au_observaciones : Comentario u obsrevaciones relacionadas a la auditoria. <br />
        /// au_estado : Estado de auditoria (A) Abierta, (P) En proceso, (C) Cerrada, (X) Anulada <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditorias
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Auditorias auditoria)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(auditoria).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro de auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// au_empresa : Codigo de la empresa <br />
        /// au_codigo : Codigo de proceso de auditoria <br />
        /// au_oficina_origen : Oficina desde la cual se origina la auditoria <br />
        /// au_oficina_destino : Oficina objeto de la auditoria <br />
        /// au_tipo_proceso : Tipo de proceso de auditoria <br />
        /// au_fecha_inicio : Fecha de inicio de la auditoria <br />
        /// au_fecha_cierre : Fecha de cierre de auditoria <br />
        /// au_tipo : Tipo de auditoria Local (L) o Remota (R) <br />
        /// au_observaciones : Comentario u obsrevaciones relacionadas a la auditoria. <br />
        /// au_estado : Estado de auditoria (A) Abierta, (P) En proceso, (C) Cerrada, (X) Anulada <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditorias
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Auditorias auditoria)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(auditoria).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta registros de auditorias
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// codigo : Codigo de proceso de auditoria. Cero (0) para consultar todos los registros de auditorias ingresados <br /><br />
        /// anio : Año de realizacion de la audioria. Cero (0) para consultar todos los registros de auditorias ingresados <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditorias
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{codigo}/{anio}")]
        public IEnumerable<Auditorias> Get(int empresa, int codigo, int anio)
        {
            List<Auditorias> list_auditorias;
            string JSONString = string.Empty;

            list_auditorias = _repository.Consulta(empresa, codigo, anio).ToList();
            return list_auditorias;
        }

        /// <summary>
        /// Consulta registros de auditorias relacionados a una plantilla especifica
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// codigo : Codigo de proceso de auditoria. Cero (0) para consultar todos los registros de auditorias ingresados <br /><br />
        /// anio : Año de realizacion de la audioria. Cero (0) para consultar todos los registros de auditorias ingresados <br /><br />
        /// plantilla : Codigo de plantilla asociada. Cero (0) para consultar todos los registros de auditorias ingresados <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditoriasPlantillas
        /// </remarks>
        [HttpGet]
        [Route("ConsultaPlantilla/{empresa}/{codigo}/{anio}/{plantilla}")]
        public IEnumerable<Auditorias> ConsultaPlantilla(int empresa, int codigo, int anio, int plantilla)
        {
            List<Auditorias> list_auditorias;
            string JSONString = string.Empty;

            list_auditorias = _repository.ConsultaPlantilla(empresa, codigo, anio, plantilla).ToList();
            return list_auditorias;
        }

        /// <summary>
        /// Consulta el resumen de los procesos de auditoria por año
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// anio : Año de consulta <br /><br />
        /// Procedimiento almacenado : api_ResumenProcesosAuditoria
        /// </remarks>
        [HttpGet]
        [Route("ConsultaResumen/{empresa}/{anio}")]
        public IEnumerable<AuditoriaResumen> ConsultaResumen(int empresa, int anio)
        {
            List<AuditoriaResumen> list_auditorias;
            string JSONString = string.Empty;

            list_auditorias = _repository.ConsultaResumen(empresa, anio).ToList();
            return list_auditorias;
        }

        /// <summary>
        /// Copia registros de tareas y de plantillas no procesadas de una auditoria previa y 
        /// los registra como una nueva auditoria
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria que se va a copiar <br /><br />
        /// Procedimiento almacenado : api_CopiaAuditoria
        /// </remarks>
        [HttpPost]
        [Route("CopiaAuditoria")]
        public async Task<string> CopiaAuditoria([FromBody] Auditorias auditoria)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.CopiaAuditoria(auditoria).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }
    }
}
