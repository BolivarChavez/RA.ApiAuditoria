using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class CategoriaGastosRepository : ICategoriaGastosRepository
    {
        readonly ApiAuditoriaContext Context;

        public CategoriaGastosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(CategoriaGastos categoriaGastos)
        {
            string sp_api = "EXEC api_ActualizaCategoriaGastos @i_cg_empresa, @i_cg_codigo, @i_cg_descripion, @i_cg_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = categoriaGastos.cg_empresa},
                new SqlParameter { ParameterName = "@i_cg_codigo", Value = categoriaGastos.cg_codigo},
                new SqlParameter { ParameterName = "@i_cg_descripion", Value = categoriaGastos.cg_descripcion},
                new SqlParameter { ParameterName = "@i_cg_estado", Value = categoriaGastos.cg_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = categoriaGastos.cg_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<CategoriaGastos> Consulta(int empresa)
        {
            string sp_api = "EXEC api_ConsultaCategoriaGastos @i_cg_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = empresa}
            };

            return Context.CategoriaGastos.FromSqlRaw<CategoriaGastos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(CategoriaGastos categoriaGastos)
        {
            string sp_api = "EXEC api_IngresoCategoriaGastos @i_cg_empresa, @i_cg_codigo, @i_cg_descripion, @i_cg_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = categoriaGastos.cg_empresa},
                new SqlParameter { ParameterName = "@i_cg_codigo", Value = categoriaGastos.cg_codigo},
                new SqlParameter { ParameterName = "@i_cg_descripion", Value = categoriaGastos.cg_descripcion},
                new SqlParameter { ParameterName = "@i_cg_estado", Value = categoriaGastos.cg_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = categoriaGastos.cg_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
