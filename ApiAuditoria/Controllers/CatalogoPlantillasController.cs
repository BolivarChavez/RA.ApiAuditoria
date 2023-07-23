using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoPlantillasController : Controller
    {
        private readonly ICatalogoPlantillasRepository _repository;
        public CatalogoPlantillasController(ICatalogoPlantillasRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CatalogoPlantillas catalogoPlantillas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(catalogoPlantillas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CatalogoPlantillas catalogoPlantillas)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(catalogoPlantillas).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        [HttpGet]
        [Route("Consulta")]
        public IEnumerable<CatalogoPlantillas> Get(int empresa)
        {
            List<CatalogoPlantillas> list_catalogo_plantillas;
            string JSONString = string.Empty;

            list_catalogo_plantillas = _repository.Consulta(empresa).ToList();
            return list_catalogo_plantillas;
        }
    }
}
