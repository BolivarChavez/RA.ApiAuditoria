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
