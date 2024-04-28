using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class MonedasRepository : IMonedasRepository
    {
        readonly ApiAuditoriaContext Context;

        public MonedasRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Monedas monedas)
        {
            string sp_api = "EXEC api_ActualizaMonedas @i_mo_codigo, @i_mo_descripcion, @i_mo_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_mo_codigo", Value = monedas.mo_codigo},
                new SqlParameter { ParameterName = "@i_mo_descripcion", Value = monedas.mo_descripcion},
                new SqlParameter { ParameterName = "@i_mo_estado", Value = monedas.mo_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = monedas.mo_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Monedas> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaMonedas @i_mo_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_mo_codigo", Value = codigo}
            };

            return Context.Monedas.FromSqlRaw<Monedas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Monedas monedas)
        {
            string sp_api = "EXEC api_IngresoMonedas @i_mo_codigo, @i_mo_descripcion, @i_mo_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_mo_codigo", Value = monedas.mo_codigo},
                new SqlParameter { ParameterName = "@i_mo_descripcion", Value = monedas.mo_descripcion},
                new SqlParameter { ParameterName = "@i_mo_estado", Value = monedas.mo_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = monedas.mo_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
