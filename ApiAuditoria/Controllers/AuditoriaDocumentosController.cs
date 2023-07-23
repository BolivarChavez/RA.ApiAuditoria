using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditoriaDocumentosController : Controller
    {
        private readonly IAuditoriaDocumentosRepository _repository;
        public AuditoriaDocumentosController(IAuditoriaDocumentosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] AuditoriaDocumentos auditoriaDocumento)
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
        public async Task<string> Actualizacion([FromBody] AuditoriaDocumentos auditoriaDocumento)
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
        [Route("Consulta")]
        public IEnumerable<AuditoriaDocumentos> Get(int empresa, int auditoria, int tarea, int plantilla)
        {
            List<AuditoriaDocumentos> list_auditoria_documento;
            string JSONString = string.Empty;

            list_auditoria_documento = _repository.Consulta(empresa, auditoria, tarea, plantilla).ToList();
            return list_auditoria_documento;
        }
    }
}
