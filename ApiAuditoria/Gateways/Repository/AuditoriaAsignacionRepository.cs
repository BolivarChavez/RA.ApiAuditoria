using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaAsignacionRepository : IAuditoriaAsignacionRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaAsignacionRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaAsignacion asignacionAuditoria)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaAsignacion @i_aa_empresa, @i_aa_auditoria, @i_aa_tarea, @i_aa_secuencia, @i_aa_responsable, @i_aa_tipo, @i_aa_rol, @i_aa_estado, @i_Usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_aa_empresa", Value = asignacionAuditoria.aa_empresa},
                new SqlParameter { ParameterName = "@i_aa_auditoria", Value = asignacionAuditoria.aa_auditoria},
                new SqlParameter { ParameterName = "@i_aa_tarea", Value = asignacionAuditoria.aa_tarea},
                new SqlParameter { ParameterName = "@i_aa_secuencia", Value = asignacionAuditoria.aa_secuencia},
                new SqlParameter { ParameterName = "@i_aa_responsable", Value = asignacionAuditoria.aa_responsable},
                new SqlParameter { ParameterName = "@i_aa_tipo", Value = asignacionAuditoria.aa_tipo},
                new SqlParameter { ParameterName = "@i_aa_rol", Value = asignacionAuditoria.aa_rol},
                new SqlParameter { ParameterName = "@i_aa_estado", Value = asignacionAuditoria.aa_estado},
                new SqlParameter { ParameterName = "@i_Usuario", Value = asignacionAuditoria.aa_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaAsignacion> Consulta(int empresa, int auditoria, int tarea)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaAsignacion @i_aa_empresa, @i_aa_auditoria, @i_aa_tarea";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_aa_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_aa_auditoria", Value = auditoria},
                new SqlParameter { ParameterName = "@i_aa_tarea", Value = tarea}
            };

            return Context.AuditoriaAsignacion.FromSqlRaw<AuditoriaAsignacion>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaAsignacion asignacionAuditoria)
        {
            string sp_api = "EXEC api_IngresoAuditoriaAsignacion @i_aa_empresa, @i_aa_auditoria, @i_aa_tarea, @i_aa_secuencia, @i_aa_responsable, @i_aa_tipo, @i_aa_rol, @i_aa_estado, @i_Usuario, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_aa_empresa", Value = asignacionAuditoria.aa_empresa},
                new SqlParameter { ParameterName = "@i_aa_auditoria", Value = asignacionAuditoria.aa_auditoria},
                new SqlParameter { ParameterName = "@i_aa_tarea", Value = asignacionAuditoria.aa_tarea},
                new SqlParameter { ParameterName = "@i_aa_secuencia", Value = asignacionAuditoria.aa_secuencia},
                new SqlParameter { ParameterName = "@i_aa_responsable", Value = asignacionAuditoria.aa_responsable},   
                new SqlParameter { ParameterName = "@i_aa_tipo", Value = asignacionAuditoria.aa_tipo},
                new SqlParameter { ParameterName = "@i_aa_rol", Value = asignacionAuditoria.aa_rol},
                new SqlParameter { ParameterName = "@i_aa_estado", Value = asignacionAuditoria.aa_estado},
                new SqlParameter { ParameterName = "@i_Usuario", Value = asignacionAuditoria.aa_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
