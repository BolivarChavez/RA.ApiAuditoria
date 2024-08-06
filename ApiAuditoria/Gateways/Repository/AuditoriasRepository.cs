using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class AuditoriasRepository : IAuditoriasRepository
    {
        readonly ApiAuditoriaContext Context;

        public AuditoriasRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Auditorias auditoria)
        {
            string sp_api = "EXEC api_ActualizaAuditorias @i_au_empresa, @i_au_codigo, @i_au_oficina_origen, @i_au_oficina_destino, @i_au_tipo_proceso, @i_au_fecha_inicio, @i_au_fecha_cierre, @i_au_tipo, @i_au_observaciones, @i_au_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_au_empresa", Value = auditoria.au_empresa},
                new SqlParameter { ParameterName = "@i_au_codigo", Value = auditoria.au_codigo},
                new SqlParameter { ParameterName = "@i_au_oficina_origen", Value = auditoria.au_oficina_origen},
                new SqlParameter { ParameterName = "@i_au_oficina_destino", Value = auditoria.au_oficina_destino},
                new SqlParameter { ParameterName = "@i_au_tipo_proceso", Value = auditoria.au_tipo_proceso},
                new SqlParameter { ParameterName = "@i_au_fecha_inicio", Value = auditoria.au_fecha_inicio},
                new SqlParameter { ParameterName = "@i_au_fecha_cierre", Value = auditoria.au_fecha_cierre},
                new SqlParameter { ParameterName = "@i_au_tipo", Value = auditoria.au_tipo},
                new SqlParameter { ParameterName = "@i_au_observaciones", Value = auditoria.au_observaciones},
                new SqlParameter { ParameterName = "@i_au_estado", Value = auditoria.au_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoria.au_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Auditorias> Consulta(int empresa, int codigo, int anio)
        {
            string sp_api = "EXEC api_ConsultaAuditorias @i_au_empresa, @i_au_codigo, @i_anio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_au_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_au_codigo", Value = codigo},
                new SqlParameter { ParameterName = "@i_anio", Value = anio}
            };

            return Context.Auditorias.FromSqlRaw<Auditorias>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Auditorias> ConsultaPlantilla(int empresa, int codigo, int anio, int plantilla)
        {
            string sp_api = "EXEC api_ConsultaAuditoriasPlantillas @i_au_empresa, @i_au_codigo, @i_anio, @i_platilla";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_au_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_au_codigo", Value = codigo},
                new SqlParameter { ParameterName = "@i_anio", Value = anio},
                new SqlParameter { ParameterName = "@i_platilla", Value = plantilla}
            };

            return Context.Auditorias.FromSqlRaw<Auditorias>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<AuditoriaResumen> ConsultaResumen(int empresa, int anio)
        {
            string sp_api = "EXEC api_ResumenProcesosAuditoria @i_empresa, @i_anio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_anio", Value = anio}
            };

            return Context.AuditoriaResumen.FromSqlRaw<AuditoriaResumen>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> CopiaAuditoria(Auditorias auditoria)
        {
            string sp_api = "EXEC api_CopiaAuditoria @i_empresa, @i_auditoria, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_empresa", Value = auditoria.au_empresa},
                new SqlParameter { ParameterName = "@i_auditoria", Value = auditoria.au_codigo},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoria.au_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Auditorias auditoria)
        {
            string sp_api = "EXEC api_IngresoAuditorias @i_au_empresa, @i_au_codigo, @i_au_oficina_origen, @i_au_oficina_destino, @i_au_tipo_proceso, @i_au_fecha_inicio, @i_au_fecha_cierre, @i_au_tipo, @i_au_observaciones, @i_au_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_au_empresa", Value = auditoria.au_empresa},
                new SqlParameter { ParameterName = "@i_au_codigo", Value = auditoria.au_codigo},
                new SqlParameter { ParameterName = "@i_au_oficina_origen", Value = auditoria.au_oficina_origen},
                new SqlParameter { ParameterName = "@i_au_oficina_destino", Value = auditoria.au_oficina_destino},
                new SqlParameter { ParameterName = "@i_au_tipo_proceso", Value = auditoria.au_tipo_proceso},
                new SqlParameter { ParameterName = "@i_au_fecha_inicio", Value = auditoria.au_fecha_inicio},
                new SqlParameter { ParameterName = "@i_au_fecha_cierre", Value = auditoria.au_fecha_cierre},
                new SqlParameter { ParameterName = "@i_au_tipo", Value = auditoria.au_tipo},
                new SqlParameter { ParameterName = "@i_au_observaciones", Value = auditoria.au_observaciones},
                new SqlParameter { ParameterName = "@i_au_estado", Value = auditoria.au_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = auditoria.au_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
