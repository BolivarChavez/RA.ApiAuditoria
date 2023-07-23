using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class CatalogoPlantillasRepository : ICatalogoPlantillasRepository
    {
        readonly ApiAuditoriaContext Context;

        public CatalogoPlantillasRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(CatalogoPlantillas catalogoPlantillas)
        {
            string sp_api = "EXEC api_ActualizaCatalogoPlantillas @i_cp_empresa, @i_cp_codigo, @i_cp_descripcion, @i_cp_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = catalogoPlantillas.cp_empresa},
                new SqlParameter { ParameterName = "@i_cp_codigo", Value = catalogoPlantillas.cp_codigo},
                new SqlParameter { ParameterName = "@i_cp_descripcion", Value = catalogoPlantillas.cp_descripcion},
                new SqlParameter { ParameterName = "@i_cp_estado", Value = catalogoPlantillas.cp_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoPlantillas.cp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<CatalogoPlantillas> Consulta(int empresa)
        {
            string sp_api = "EXEC api_ConsultaCatalogoPlantillas @i_cp_empresa";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = empresa}
            };

            return Context.CatalogoPlantillas.FromSqlRaw<CatalogoPlantillas>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(CatalogoPlantillas catalogoPlantillas)
        {
            string sp_api = "EXEC api_IngresoCatalogoPlantillas @i_cp_empresa, @i_cp_codigo, @i_cp_descripcion, @i_cp_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_cp_empresa", Value = catalogoPlantillas.cp_empresa},
                new SqlParameter { ParameterName = "@i_cp_codigo", Value = catalogoPlantillas.cp_codigo},
                new SqlParameter { ParameterName = "@i_cp_descripcion", Value = catalogoPlantillas.cp_descripcion},
                new SqlParameter { ParameterName = "@i_cp_estado", Value = catalogoPlantillas.cp_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = catalogoPlantillas.cp_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
