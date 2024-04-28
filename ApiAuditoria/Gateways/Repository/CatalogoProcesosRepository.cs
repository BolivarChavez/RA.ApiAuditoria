using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class CatalogoProcesosRepository : ICatalogoProcesosRepository
    {
        readonly ApiAuditoriaContext Context;

        public CatalogoProcesosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(CatalogoProcesos catalogoProcesos)
        {
            string sp_api = "EXEC api_ActualizaCatalogoProcesos @i_cp_empresa, @i_cp_codigo, @i_cp_descripcion, @i_cp_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = catalogoProcesos.cp_empresa},
                new SqlParameter { ParameterName = "@i_cp_codigo", Value = catalogoProcesos.cp_codigo},
                new SqlParameter { ParameterName = "@i_cp_descripcion", Value = catalogoProcesos.cp_descripcion},
                new SqlParameter { ParameterName = "@i_cp_estado", Value = catalogoProcesos.cp_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoProcesos.cp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<CatalogoProcesos> Consulta(int empresa)
        {
            string sp_api = "EXEC api_ConsultaCatalogoProcesos @i_cp_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = empresa}
            };

            return Context.CatalogoProcesos.FromSqlRaw<CatalogoProcesos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(CatalogoProcesos catalogoProcesos)
        {
            string sp_api = "EXEC api_IngresoCatalogoProcesos @i_cp_empresa, @i_cp_codigo, @i_cp_descripcion, @i_cp_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = catalogoProcesos.cp_empresa},
                new SqlParameter { ParameterName = "@i_cp_codigo", Value = catalogoProcesos.cp_codigo},
                new SqlParameter { ParameterName = "@i_cp_descripcion", Value = catalogoProcesos.cp_descripcion},
                new SqlParameter { ParameterName = "@i_cp_estado", Value = catalogoProcesos.cp_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoProcesos.cp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
