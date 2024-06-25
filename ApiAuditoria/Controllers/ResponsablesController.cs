using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResponsablesController : Controller
    {
        private readonly IResponsablesRepository _repository;
        public ResponsablesController(IResponsablesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserta un nuevo registro de la tabla de responsables de auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// re_empresa : Codigo de empresa <br />
        /// re_codigo  : Codigo del responsable <br />
        /// re_nombre  : Nombre del responsable <br />
        /// re_cargo   : Descripcion del cargo del responsable <br />
        /// re_oficina : Codigo de la oficina de origen del responsable <br />
        /// re_tipo    : Tipo de responsable (A) Auditor, (J) Jefe de auditoria, (R) Responsable de informacion <br />
        /// re_correo  : Correo electronico del responsable <br />
        /// re_usuario : Nombre de usuario relacionado al responsable <br />
        /// re_estado  : Estado del registro (A) Activo, (I) Inactivo, (X) Eliminado <br /><br />
        /// Procedimiento almacenado : api_IngresoResponsables
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] Responsables responsables)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(responsables).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro de la tabla de responsables de auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// re_empresa : Codigo de empresa <br />
        /// re_codigo  : Codigo del responsable <br />
        /// re_nombre  : Nombre del responsable <br />
        /// re_cargo   : Descripcion del cargo del responsable <br />
        /// re_oficina : Codigo de la oficina de origen del responsable <br />
        /// re_tipo    : Tipo de responsable (A) Auditor, (J) Jefe de auditoria, (R) Responsable de informacion <br />
        /// re_correo  : Correo electronico del responsable <br />
        /// re_usuario : Nombre de usuario relacionado al responsable <br />
        /// re_estado  : Estado del registro (A) Activo, (I) Inactivo, (X) Eliminado <br /><br />
        /// Procedimiento almacenado : api_ActualizaResponsables
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] Responsables responsables)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(responsables).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta los registros de la tabla de responsables de auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// codigo : Codigo de empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaResponsables
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{codigo}")]
        public IEnumerable<Responsables> Get(int codigo)
        {
            List<Responsables> list_responsables;
            string JSONString = string.Empty;

            list_responsables = _repository.Consulta(codigo).ToList();
            return list_responsables;
        }
    }
}
