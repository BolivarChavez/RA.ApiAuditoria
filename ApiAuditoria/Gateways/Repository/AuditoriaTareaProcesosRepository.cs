using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaTareaProcesosRepository : IAuditoriaTareaProcesosRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaTareaProcesosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaTareaProcesos auditoriaTareaProcesos)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaTareaProcesos @i_at_empresa, @i_at_auditoria, @i_at_tarea, @i_at_secuencia, @i_at_auditor, @i_at_responsable, @i_at_fecha, @i_at_observaciones, @i_at_documento, @i_at_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = auditoriaTareaProcesos.at_empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoriaTareaProcesos.at_auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = auditoriaTareaProcesos.at_tarea},
                new SqlParameter { ParameterName = "@i_at_secuencia", Value = auditoriaTareaProcesos.at_secuencia},
                new SqlParameter { ParameterName = "@i_at_auditor", Value = auditoriaTareaProcesos.at_auditor},
                new SqlParameter { ParameterName = "@i_at_responsable", Value = auditoriaTareaProcesos.at_responsable},
                new SqlParameter { ParameterName = "@i_at_fecha", Value = auditoriaTareaProcesos.at_fecha},
                new SqlParameter { ParameterName = "@i_at_observaciones", Value = auditoriaTareaProcesos.at_observaciones},
                new SqlParameter { ParameterName = "@i_at_documento", Value = auditoriaTareaProcesos.at_documento},
                new SqlParameter { ParameterName = "@i_at_estado", Value = auditoriaTareaProcesos.at_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaTareaProcesos.at_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaTareaProcesos> Consulta(int empresa, int auditoria, int tarea)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaTareaProcesos @i_at_empresa, @i_at_auditoria, @i_at_tarea";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = tarea}
            };

            return Context.AuditoriaTareaProcesos.FromSqlRaw<AuditoriaTareaProcesos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaTareaProcesos auditoriaTareaProcesos)
        {
            string sp_api = "EXEC api_IngresoAuditoriaTareaProcesos @i_at_empresa, @i_at_auditoria, @i_at_tarea, @i_at_secuencia, @i_at_auditor, @i_at_responsable, @i_at_fecha, @i_at_observaciones, @i_at_documento, @i_at_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = auditoriaTareaProcesos.at_empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoriaTareaProcesos.at_auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = auditoriaTareaProcesos.at_tarea},
                new SqlParameter { ParameterName = "@i_at_secuencia", Value = auditoriaTareaProcesos.at_secuencia},
                new SqlParameter { ParameterName = "@i_at_auditor", Value = auditoriaTareaProcesos.at_auditor},
                new SqlParameter { ParameterName = "@i_at_responsable", Value = auditoriaTareaProcesos.at_responsable},
                new SqlParameter { ParameterName = "@i_at_fecha", Value = auditoriaTareaProcesos.at_fecha},
                new SqlParameter { ParameterName = "@i_at_observaciones", Value = auditoriaTareaProcesos.at_observaciones},
                new SqlParameter { ParameterName = "@i_at_documento", Value = auditoriaTareaProcesos.at_documento},
                new SqlParameter { ParameterName = "@i_at_estado", Value = auditoriaTareaProcesos.at_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaTareaProcesos.at_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
