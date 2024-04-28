using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class CatalogoTareasRepository : ICatalogoTareasRepository
    {
        readonly ApiAuditoriaContext Context;

        public CatalogoTareasRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(CatalogoTareas catalogoTareas)
        {
            string sp_api = "EXEC api_ActualizaCatalogoTareas @i_ct_empresa, @i_ct_proceso, @i_ct_codigo, @i_ct_descripcion, @i_ct_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ct_empresa", Value = catalogoTareas.ct_empresa},
                new SqlParameter { ParameterName = "@i_ct_proceso", Value = catalogoTareas.ct_proceso},
                new SqlParameter { ParameterName = "@i_ct_codigo", Value = catalogoTareas.ct_codigo},
                new SqlParameter { ParameterName = "@i_ct_descripcion", Value = catalogoTareas.ct_descripcion},
                new SqlParameter { ParameterName = "@i_ct_estado", Value = catalogoTareas.ct_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoTareas.ct_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<CatalogoTareas> Consulta(int empresa)
        {
            string sp_api = "EXEC api_ConsultaCatalogoTareas @i_ct_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ct_empresa", Value = empresa}
            };

            return Context.CatalogoTareas.FromSqlRaw<CatalogoTareas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(CatalogoTareas catalogoTareas)
        {
            string sp_api = "EXEC api_IngresoCatalogoTareas @i_ct_empresa, @i_ct_proceso, @i_ct_codigo, @i_ct_descripcion, @i_ct_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ct_empresa", Value = catalogoTareas.ct_empresa},
                new SqlParameter { ParameterName = "@i_ct_proceso", Value = catalogoTareas.ct_proceso},
                new SqlParameter { ParameterName = "@i_ct_codigo", Value = catalogoTareas.ct_codigo},
                new SqlParameter { ParameterName = "@i_ct_descripcion", Value = catalogoTareas.ct_descripcion},
                new SqlParameter { ParameterName = "@i_ct_estado", Value = catalogoTareas.ct_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoTareas.ct_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
