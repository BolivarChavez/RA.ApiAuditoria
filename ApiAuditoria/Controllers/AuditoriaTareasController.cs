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
