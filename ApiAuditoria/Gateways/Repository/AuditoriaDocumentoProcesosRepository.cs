using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaDocumentoProcesosRepository : IAuditoriaDocumentoProcesosRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaDocumentoProcesosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaDocumentoProcesos auditoriaDocumentoProceso)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaDocumentoProcesos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_codigo, @i_ad_secuencia, @i_ad_fecha, @i_ad_auditor, @i_ad_responsable, @i_ad_observaciones, @i_ad_documento, @i_ad_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = auditoriaDocumentoProceso.ad_empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoriaDocumentoProceso.ad_auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = auditoriaDocumentoProceso.ad_tarea},
                new SqlParameter { ParameterName = "@i_ad_codigo", Value = auditoriaDocumentoProceso.ad_codigo},
                new SqlParameter { ParameterName = "@i_ad_secuencia", Value = auditoriaDocumentoProceso.ad_secuencia},
                new SqlParameter { ParameterName = "@i_ad_fecha", Value = auditoriaDocumentoProceso.ad_fecha},
                new SqlParameter { ParameterName = "@i_ad_auditor", Value = auditoriaDocumentoProceso.ad_auditor},
                new SqlParameter { ParameterName = "@i_ad_responsable", Value = auditoriaDocumentoProceso.ad_responsable},
                new SqlParameter { ParameterName = "@i_ad_observaciones", Value = auditoriaDocumentoProceso.ad_observaciones},
                new SqlParameter { ParameterName = "@i_ad_documento", Value = auditoriaDocumentoProceso.ad_documento},
                new SqlParameter { ParameterName = "@i_ad_estado", Value = auditoriaDocumentoProceso.ad_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaDocumentoProceso.ad_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaDocumentoProcesos> Consulta(int empresa, int auditoria, int tarea, int codigo)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaDocumentoProcesos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_codigo";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = tarea},
                new SqlParameter { ParameterName = "@i_ad_codigo", Value = codigo}
            };

            return Context.AuditoriaDocumentoProcesos.FromSqlRaw<AuditoriaDocumentoProcesos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaDocumentoProcesos auditoriaDocumentoProceso)
        {
            string sp_api = "EXEC api_IngresoAuditoriaDocumentoProcesos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_codigo, @i_ad_secuencia, @i_ad_fecha, @i_ad_auditor, @i_ad_responsable, @i_ad_observaciones, @i_ad_documento, @i_ad_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = auditoriaDocumentoProceso.ad_empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoriaDocumentoProceso.ad_auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = auditoriaDocumentoProceso.ad_tarea},
                new SqlParameter { ParameterName = "@i_ad_codigo", Value = auditoriaDocumentoProceso.ad_codigo},
                new SqlParameter { ParameterName = "@i_ad_secuencia", Value = auditoriaDocumentoProceso.ad_secuencia},
                new SqlParameter { ParameterName = "@i_ad_fecha", Value = auditoriaDocumentoProceso.ad_fecha},
                new SqlParameter { ParameterName = "@i_ad_auditor", Value = auditoriaDocumentoProceso.ad_auditor},
                new SqlParameter { ParameterName = "@i_ad_responsable", Value = auditoriaDocumentoProceso.ad_responsable},
                new SqlParameter { ParameterName = "@i_ad_observaciones", Value = auditoriaDocumentoProceso.ad_observaciones},
                new SqlParameter { ParameterName = "@i_ad_documento", Value = auditoriaDocumentoProceso.ad_documento},
                new SqlParameter { ParameterName = "@i_ad_estado", Value = auditoriaDocumentoProceso.ad_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaDocumentoProceso.ad_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
