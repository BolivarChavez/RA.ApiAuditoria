using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaGastosRepository : IAuditoriaGastosRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaGastosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaGastos auditoriaGastos)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaGastos @i_ag_empresa, @i_ag_auditoria, @i_ag_secuencia, @i_ag_tipo, @i_ag_fecha_inicio, @i_ag_fecha_fin, @i_ag_valor, @i_ag_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ag_empresa", Value = auditoriaGastos.ag_empresa},
                new SqlParameter { ParameterName = "@i_ag_auditoria", Value = auditoriaGastos.ag_auditoria},
                new SqlParameter { ParameterName = "@i_ag_secuencia", Value = auditoriaGastos.ag_secuencia},
                new SqlParameter { ParameterName = "@i_ag_tipo", Value = auditoriaGastos.ag_tipo},
                new SqlParameter { ParameterName = "@i_ag_fecha_inicio", Value = auditoriaGastos.ag_fecha_inicio},
                new SqlParameter { ParameterName = "@i_ag_fecha_fin", Value = auditoriaGastos.ag_fecha_fin},
                new SqlParameter { ParameterName = "@i_ag_valor", Value = auditoriaGastos.ag_valor},
                new SqlParameter { ParameterName = "@i_ag_estado", Value = auditoriaGastos.ag_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaGastos.ag_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaGastos> Consulta(int empresa, int auditoria)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaGastos @i_ag_empresa, @i_ag_auditoria";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ag_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_ag_auditoria", Value = auditoria}
            };

            return Context.AuditoriaGastos.FromSqlRaw<AuditoriaGastos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaGastos auditoriaGastos)
        {
            string sp_api = "EXEC api_IngresoAuditoriaGastos @i_ag_empresa, @i_ag_auditoria, @i_ag_secuencia, @i_ag_tipo, @i_ag_fecha_inicio, @i_ag_fecha_fin, @i_ag_valor, @i_ag_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ag_empresa", Value = auditoriaGastos.ag_empresa},
                new SqlParameter { ParameterName = "@i_ag_auditoria", Value = auditoriaGastos.ag_auditoria},
                new SqlParameter { ParameterName = "@i_ag_secuencia", Value = auditoriaGastos.ag_secuencia},
                new SqlParameter { ParameterName = "@i_ag_tipo", Value = auditoriaGastos.ag_tipo},
                new SqlParameter { ParameterName = "@i_ag_fecha_inicio", Value = auditoriaGastos.ag_fecha_inicio},
                new SqlParameter { ParameterName = "@i_ag_fecha_fin", Value = auditoriaGastos.ag_fecha_fin},
                new SqlParameter { ParameterName = "@i_ag_valor", Value = auditoriaGastos.ag_valor},
                new SqlParameter { ParameterName = "@i_ag_estado", Value = auditoriaGastos.ag_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaGastos.ag_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
