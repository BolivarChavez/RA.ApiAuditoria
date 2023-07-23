using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaTareasRepository : IAuditoriaTareasRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaTareasRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaTareas auditoriaTarea)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaTareas @i_at_empresa, @i_at_auditoria, @i_at_tarea, @i_at_oficina, @i_at_asignacion, @i_at_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = auditoriaTarea.at_empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoriaTarea.at_auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = auditoriaTarea.at_tarea},
                new SqlParameter { ParameterName = "@i_at_oficina", Value = auditoriaTarea.at_oficina},
                new SqlParameter { ParameterName = "@i_at_asignacion", Value = auditoriaTarea.at_asignacion},
                new SqlParameter { ParameterName = "@i_at_estado", Value = auditoriaTarea.at_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaTarea.at_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaTareas> Consulta(int empresa, int auditoria, int tarea)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaTareas @i_at_empresa, @i_at_auditoria, @i_at_tarea";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = tarea}
            };

            return Context.AuditoriaTareas.FromSqlRaw<AuditoriaTareas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaTareas auditoriaTarea)
        {
            string sp_api = "EXEC api_IngresoAuditoriaTareas @i_at_empresa, @i_at_auditoria, @i_at_tarea, @i_at_oficina, @i_at_asignacion, @i_at_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_at_empresa", Value = auditoriaTarea.at_empresa},
                new SqlParameter { ParameterName = "@i_at_auditoria", Value = auditoriaTarea.at_auditoria},
                new SqlParameter { ParameterName = "@i_at_tarea", Value = auditoriaTarea.at_tarea},
                new SqlParameter { ParameterName = "@i_at_oficina", Value = auditoriaTarea.at_oficina},
                new SqlParameter { ParameterName = "@i_at_asignacion", Value = auditoriaTarea.at_asignacion},
                new SqlParameter { ParameterName = "@i_at_estado", Value = auditoriaTarea.at_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaTarea.at_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
