using ApiAuditoria.Gateways.DataContext;
using ApiAuditoria.Interfaces;
using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiAuditoria.Gateways.Repository
{
    public class CotizacionesRepository : ICotizacionesRepository
    {
        readonly ApiAuditoriaContext Context;

        public CotizacionesRepository(ApiAuditoriaContext context)
        {
            Context = context;
        }

        public IEnumerable<Retorno> Actualizacion(Cotizaciones cotizaciones)
        {
            string sp_api = "EXEC api_ActualizaCotizaciones @i_co_empresa, @i_co_moneda_base, @i_co_moneda_destino, @i_co_cotizacion, @i_co_fecha_vigencia, @i_co_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_co_empresa", Value = cotizaciones.co_empresa},
                new SqlParameter { ParameterName = "@i_co_moneda_base", Value = cotizaciones.co_moneda_base},
                new SqlParameter { ParameterName = "@i_co_moneda_destino", Value = cotizaciones.co_moneda_destino},
                new SqlParameter { ParameterName = "@i_co_cotizacion", Value = cotizaciones.co_cotizacion},
                new SqlParameter { ParameterName = "@i_co_fecha_vigencia", Value = cotizaciones.co_fecha_vigencia},
                new SqlParameter { ParameterName = "@i_co_estado", Value = cotizaciones.co_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = cotizaciones.co_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Cotizaciones> Consulta(int empresa, int monedaBase, int monedaDestino, int anio)
        {
            string sp_api = "EXEC api_ConsultaCotizaciones @i_co_empresa, @i_co_moneda_base, @i_co_moneda_destino, @i_anio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_ct_empresa", Value = empresa},
                new SqlParameter { ParameterName = "@i_co_moneda_base", Value = monedaBase},
                new SqlParameter { ParameterName = "@i_co_moneda_destino", Value = monedaDestino},
                new SqlParameter { ParameterName = "@i_anio", Value = anio}
            };

            return Context.Cotizaciones.FromSqlRaw<Cotizaciones>(sp_api, parms.ToArray()).ToList();
        }

        public IEnumerable<Retorno> Ingreso(Cotizaciones cotizaciones)
        {
            string sp_api = "EXEC api_IngresoCotizaciones @i_co_empresa, @i_co_moneda_base, @i_co_moneda_destino, @i_co_cotizacion, @i_co_fecha_vigencia, @i_co_estado, @i_Operador, @o_return, @o_msg";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@i_co_empresa", Value = cotizaciones.co_empresa},
                new SqlParameter { ParameterName = "@i_co_moneda_base", Value = cotizaciones.co_moneda_base},
                new SqlParameter { ParameterName = "@i_co_moneda_destino", Value = cotizaciones.co_moneda_destino},
                new SqlParameter { ParameterName = "@i_co_cotizacion", Value = cotizaciones.co_cotizacion},
                new SqlParameter { ParameterName = "@i_co_fecha_vigencia", Value = cotizaciones.co_fecha_vigencia},
                new SqlParameter { ParameterName = "@i_co_estado", Value = cotizaciones.co_estado},
                new SqlParameter { ParameterName = "@i_Operador", Value = cotizaciones.co_usuario_creacion},
                new SqlParameter { ParameterName = "@o_return", Value = 0},
                new SqlParameter { ParameterName = "@o_msg", Value = ""}
            };

            return Context.Retorno.FromSqlRaw<Retorno>(sp_api, parms.ToArray()).ToList();
        }
    }
}
