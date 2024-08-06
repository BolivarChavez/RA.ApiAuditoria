using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriaDocumentosRepository : IAuditoriaDocumentosRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriaDocumentosRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(AuditoriaDocumentos auditoriaDocumentos)
        {
            string sp_api = "EXEC api_ActualizaAuditoriaDocumentos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_codigo, @i_ad_plantilla, @i_ad_referencia, @i_ad_registro, @i_ad_auditoria_origen, @i_ad_responsable, @i_ad_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = auditoriaDocumentos.ad_empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoriaDocumentos.ad_auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = auditoriaDocumentos.ad_tarea},
                new SqlParameter { ParameterName = "@i_ad_codigo", Value = auditoriaDocumentos.ad_codigo},
                new SqlParameter { ParameterName = "@i_ad_plantilla", Value = auditoriaDocumentos.ad_plantilla},
                new SqlParameter { ParameterName = "@i_ad_referencia", Value = auditoriaDocumentos.ad_referencia},
                new SqlParameter { ParameterName = "@i_ad_registro", Value = auditoriaDocumentos.ad_registro},
                new SqlParameter { ParameterName = "@i_ad_auditoria_origen", Value = auditoriaDocumentos.ad_auditoria_origen},
                new SqlParameter { ParameterName = "@i_ad_responsable", Value = auditoriaDocumentos.ad_responsable},
                new SqlParameter { ParameterName = "@i_ad_estado", Value = auditoriaDocumentos.ad_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaDocumentos.ad_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaDocumentos> Consulta(int empresa, int auditoria, int tarea, int plantilla, int anio)
        {
            string sp_api = "EXEC api_ConsultaAuditoriaDocumentos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_plantilla, @i_anio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = tarea},
                new SqlParameter { ParameterName = "@i_ad_plantilla", Value = plantilla},
                new SqlParameter { ParameterName = "@i_anio", Value = anio}
            };

            return Context.AuditoriaDocumentos.FromSqlRaw<AuditoriaDocumentos>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(AuditoriaDocumentos auditoriaDocumentos)
        {
            string sp_api = "EXEC api_IngresoAuditoriaDocumentos @i_ad_empresa, @i_ad_auditoria, @i_ad_tarea, @i_ad_codigo, @i_ad_plantilla, @i_ad_referencia, @i_ad_registro, @i_ad_auditoria_origen, @i_ad_responsable, @i_ad_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ad_empresa", Value = auditoriaDocumentos.ad_empresa},
                new SqlParameter { ParameterName = "@i_ad_auditoria", Value = auditoriaDocumentos.ad_auditoria},
                new SqlParameter { ParameterName = "@i_ad_tarea", Value = auditoriaDocumentos.ad_tarea},
                new SqlParameter { ParameterName = "@i_ad_codigo", Value = auditoriaDocumentos.ad_codigo},
                new SqlParameter { ParameterName = "@i_ad_plantilla", Value = auditoriaDocumentos.ad_plantilla},
                new SqlParameter { ParameterName = "@i_ad_referencia", Value = auditoriaDocumentos.ad_referencia},
                new SqlParameter { ParameterName = "@i_ad_registro", Value = auditoriaDocumentos.ad_registro},
                new SqlParameter { ParameterName = "@i_ad_auditoria_origen", Value = auditoriaDocumentos.ad_auditoria_origen},
                new SqlParameter { ParameterName = "@i_ad_responsable", Value = auditoriaDocumentos.ad_responsable},
                new SqlParameter { ParameterName = "@i_ad_estado", Value = auditoriaDocumentos.ad_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoriaDocumentos.ad_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
