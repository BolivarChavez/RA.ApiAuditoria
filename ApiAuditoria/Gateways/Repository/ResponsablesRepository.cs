using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class ResponsablesRepository : IResponsablesRepository
    {
        readonly ApiAuditoriaContext Context;

        public ResponsablesRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Responsables responsables)
        {
            string sp_api = "EXEC api_ActualizaResponsables @i_re_empresa, @i_re_codigo, @i_re_nombre, @i_re_cargo, @i_re_oficina, @i_re_tipo, @i_re_correo, @i_re_usuario, @i_re_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_re_empresa", Value = responsables.re_empresa},
                new SqlParameter { ParameterName = "@i_re_codigo", Value = responsables.re_codigo},
                new SqlParameter { ParameterName = "@i_re_nombre", Value = responsables.re_nombre},
                new SqlParameter { ParameterName = "@i_re_cargo", Value = responsables.re_cargo},
                new SqlParameter { ParameterName = "@i_re_oficina", Value = responsables.re_oficina},
                new SqlParameter { ParameterName = "@i_re_tipo", Value = responsables.re_tipo},
                new SqlParameter { ParameterName = "@i_re_correo", Value = responsables.re_correo},
                new SqlParameter { ParameterName = "@i_re_usuario", Value = responsables.re_usuario},
                new SqlParameter { ParameterName = "@i_re_estado", Value = responsables.re_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = responsables.re_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Responsables> Consulta(int codigo)
        {
            string sp_api = "EXEC api_ConsultaResponsables @i_re_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_re_empresa", Value = codigo}
            };

            return Context.Responsables.FromSqlRaw<Responsables>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Responsables responsables)
        {
            string sp_api = "EXEC api_IngresoResponsables @i_re_empresa, @i_re_codigo, @i_re_nombre, @i_re_cargo, @i_re_oficina, @i_re_tipo, @i_re_correo, @i_re_usuario, @i_re_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_re_empresa", Value = responsables.re_empresa},
                new SqlParameter { ParameterName = "@i_re_codigo", Value = responsables.re_codigo},
                new SqlParameter { ParameterName = "@i_re_nombre", Value = responsables.re_nombre},
                new SqlParameter { ParameterName = "@i_re_cargo", Value = responsables.re_cargo},
                new SqlParameter { ParameterName = "@i_re_oficina", Value = responsables.re_oficina},
                new SqlParameter { ParameterName = "@i_re_tipo", Value = responsables.re_tipo},
                new SqlParameter { ParameterName = "@i_re_correo", Value = responsables.re_correo},
                new SqlParameter { ParameterName = "@i_re_usuario", Value = responsables.re_usuario},
                new SqlParameter { ParameterName = "@i_re_estado", Value = responsables.re_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = responsables.re_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
