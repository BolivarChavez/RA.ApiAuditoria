using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading;

namespace ApiAuditoria.Gateways.Repository
{
    public class CatalogoGastosRepository : ICatalogoGastosRepository
    {
        readonly ApiAuditoriaContext Context;

        public CatalogoGastosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(CatalogoGastos catalogoGastos)
        {
            string sp_api = "EXEC api_ActualizaCatalogoGastos @i_cg_empresa, @i_cg_codigo, @i_cg_descripion, @i_cg_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = catalogoGastos.cg_empresa},
                new SqlParameter { ParameterName = "@i_cg_codigo", Value = catalogoGastos.cg_codigo},
                new SqlParameter { ParameterName = "@i_cg_descripion", Value = catalogoGastos.cg_descripion},
                new SqlParameter { ParameterName = "@i_cg_estado", Value = catalogoGastos.cg_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoGastos.cg_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<CatalogoGastos> Consulta(int empresa)
        {
            string sp_api = "EXEC api_ConsultaCatalogoGastos @i_cg_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = empresa}
            };

            return Context.CatalogoGastos.FromSqlRaw<CatalogoGastos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(CatalogoGastos catalogoGastos)
        {
            string sp_api = "EXEC api_IngresoCatalogoGastos @i_cg_empresa, @i_cg_codigo, @i_cg_descripion, @i_cg_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cg_empresa", Value = catalogoGastos.cg_empresa},
                new SqlParameter { ParameterName = "@i_cg_codigo", Value = catalogoGastos.cg_codigo},
                new SqlParameter { ParameterName = "@i_cg_descripion", Value = catalogoGastos.cg_descripion},
                new SqlParameter { ParameterName = "@i_cg_estado", Value = catalogoGastos.cg_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoGastos.cg_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
