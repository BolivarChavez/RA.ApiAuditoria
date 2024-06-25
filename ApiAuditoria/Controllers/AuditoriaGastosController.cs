using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaGastosController : Controller
    {
        private readonly IAuditoriaGastosRepository _repository;
        public AuditoriaGastosController(IAuditoriaGastosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ingresa un registro de gasto relacionado a una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ag_empresa : Codigo de la empresa <br />
        /// ag_auditoria : Codigo de la auditoria <br />
        /// ag_secuencia : Secuencia de registro de gasto <br />
        /// ag_tipo : Tipo de Gasto <br />
        /// ag_fecha_inicio : Fecha de inicio de referencia <br />
        /// ag_fecha_fin : Fecha de fin de referencia <br />
        /// ag_valor : Total de gasto <br />
        /// ag_estado : Estado de registro Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoAuditoriaGastos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaGastos auditoriaGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(auditoriaGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro de gasto relacionado a una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// ag_empresa : Codigo de la empresa <br />
        /// ag_auditoria : Codigo de la auditoria <br />
        /// ag_secuencia : Secuencia de registro de gasto <br />
        /// ag_tipo : Tipo de Gasto <br />
        /// ag_fecha_inicio : Fecha de inicio de referencia <br />
        /// ag_fecha_fin : Fecha de fin de referencia <br />
        /// ag_valor : Total de gasto <br />
        /// ag_estado : Estado de registro Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaAuditoriaGastos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaGastos auditoriaGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(auditoriaGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros de gastos relacionados a una auditoria 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br />
        /// auditoria : Codigo de la auditoria <br /><br />
        /// Procedimiento almacenado : api_ConsultaAuditoriaGastos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}")]
        public IEnumerable<AuditoriaGastos> Get(int empresa, int auditoria)
        {
            List<AuditoriaGastos> list_auditoria_gastos;
            string JSONString = string.Empty;

            list_auditoria_gastos = _repository.Consulta(empresa, auditoria).ToList();
            return list_auditoria_gastos;
        }
    }
}
