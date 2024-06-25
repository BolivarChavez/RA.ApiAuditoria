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

        /// <summary>
        /// Inserta un nuevo registro del catalogo de plantillas de informacion para auditar 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cp_empresa : Codigo de la empresa <br />
        /// cp_codigo : Codigo de la plantilla <br />
        /// cp_descripcion : Descripcion de la plantilla <br />
        /// cp_estado : Estado de registro Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoCatalogoPlantillas
        /// </remarks>
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

        /// <summary>
        /// Actualiza un registro del catalogo de plantillas de informacion para auditar 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cp_empresa : Codigo de la empresa <br />
        /// cp_codigo : Codigo de la plantilla <br />
        /// cp_descripcion : Descripcion de la plantilla <br />
        /// cp_estado : Estado de registro Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaCatalogoPlantillas
        /// </remarks>
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

        /// <summary>
        /// Consulta los registros del catalogo de plantillas de informacion para auditar 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de la empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaCatalogoPlantillas
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CatalogoPlantillas> Get(int empresa)
        {
            List<CatalogoPlantillas> list_catalogo_plantillas;
            string JSONString = string.Empty;

            list_catalogo_plantillas = _repository.Consulta(empresa).ToList();
            return list_catalogo_plantillas;
        }
    }
}
