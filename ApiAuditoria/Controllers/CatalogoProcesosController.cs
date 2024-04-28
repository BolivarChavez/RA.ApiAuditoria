using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoProcesosController : Controller
    {
        private readonly ICatalogoProcesosRepository _repository;
        public CatalogoProcesosController(ICatalogoProcesosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoProcesos catalogoProcesos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoProcesos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoProcesos catalogoProcesos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoProcesos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoProcesos> Get(int empresa)
        {
            List<CatalogoProcesos> list_catalogo_procesos;
            string JSONString = string.Empty;

            list_catalogo_procesos = _repository.Consulta(empresa).ToList();
            return list_catalogo_procesos;
        }
    }
}
