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
