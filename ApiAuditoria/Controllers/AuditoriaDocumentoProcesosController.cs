using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaDocumentoProcesosController : Controller
    {
        private readonly IAuditoriaDocumentoProcesosRepository _repository;
        public AuditoriaDocumentoProcesosController(IAuditoriaDocumentoProcesosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaDocumentoProcesos auditoriaDocumento)
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

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] AuditoriaDocumentoProcesos auditoriaDocumento)
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

        [HttpGet]
        [Route("Consulta/{empresa}/{auditoria}/{tarea}/{codigo}")]
        public IEnumerable<AuditoriaDocumentoProcesos> Get(int empresa, int auditoria, int tarea, int codigo)
        {
            List<AuditoriaDocumentoProcesos> list_auditoria_documento_procesos;
            string JSONString = string.Empty;

            list_auditoria_documento_procesos = _repository.Consulta(empresa, auditoria, tarea, codigo).ToList();
            return list_auditoria_documento_procesos;
        }
    }
}
