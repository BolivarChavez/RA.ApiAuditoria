using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiAuditoria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaGastosController : Controller
    {
        private readonly ICategoriaGastosRepository _repository;
        public CategoriaGastosController(ICategoriaGastosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserta un nuevo registro del catalogo de categorias de gastos relacionados a auditorias 
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cg_empresa : Codigo de empresa <br />
        /// cg_codigo : Codigo de la categoria de gasto <br />
        /// cg_descripion : Descripcion de la categoria de gasto <br />
        /// cg_estado : Estado de registro de la categoria de gasto Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_IngresoCategoriaGastos
        /// </remarks>
        [HttpPost]
        [Route("Ingreso")]
        public async Task<string> Ingreso([FromBody] CategoriaGastos categoriaGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Ingreso(categoriaGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Actualiza un registro del catalogo catalogo de categorias de gastos relacionados a auditorias
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// cg_empresa : Codigo de empresa <br />
        /// cg_codigo : Codigo de la categoria de gasto <br />
        /// cg_descripion : Descripcion de la categoria de gasto <br />
        /// cg_estado : Estado de registro de la categoria de gasto Activo (A), Inactivo (I), Eliminado (X) <br /><br />
        /// Procedimiento almacenado : api_ActualizaCategoriaGastos
        /// </remarks>
        [HttpPost]
        [Route("Actualizacion")]
        public async Task<string> Actualizacion([FromBody] CategoriaGastos categoriaGastos)
        {
            List<Retorno> list_retorno;
            string JSONString = string.Empty;

            await Task.Run(() =>
            {
                list_retorno = _repository.Actualizacion(categoriaGastos).ToList();
                JSONString = JsonSerializer.Serialize(list_retorno);
            });

            return JSONString;
        }

        /// <summary>
        /// Consulta registros de las categrias de gastos relacionados a auditorias
        /// </summary>
        /// <remarks>
        /// <b>Parametros</b><br />
        /// empresa : Codigo de empresa <br /><br />
        /// Procedimiento almacenado : api_ConsultaCategoriaGastos
        /// </remarks>
        [HttpGet]
        [Route("Consulta/{empresa}")]
        public IEnumerable<CategoriaGastos> Get(int empresa)
        {
            List<CategoriaGastos> list_catalogo_gastos;
            string JSONString = string.Empty;

            list_catalogo_gastos = _repository.Consulta(empresa).ToList();
            return list_catalogo_gastos;
        }
    }
}
