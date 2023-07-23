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

        [HttpGet]
        [Route("Consulta")]
        public IEnumerable<AuditoriaAsignacion> Get(int empresa, int auditoria, int tarea)
        {
            List<AuditoriaAsignacion> list_auditoria_asignacion;
            string JSONString = string.Empty;

            list_auditoria_asignacion = _repository.Consulta(empresa, auditoria, tarea).ToList();
            return list_auditoria_asignacion;
        }
    }
}
