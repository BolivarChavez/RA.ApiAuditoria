using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoTareasController : Controller
    {
        private readonly ICatalogoTareasRepository _repository;
        public CatalogoTareasController(ICatalogoTareasRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoTareas catalogoTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoTareas catalogoTareas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoTareas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoTareas> Get(int empresa)
        {
            List<CatalogoTareas> list_catalogo_tareas;
            string JSONString = string.Empty;

            list_catalogo_tareas = _repository.Consulta(empresa).ToList();
            return list_catalogo_tareas;
        }
    }
}
