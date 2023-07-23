using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICotizacionesRepository
    {
        IEnumerable<Retorno> Ingreso(Cotizaciones cotizaciones);

        IEnumerable<Retorno> Actualizacion(Cotizaciones cotizaciones);

        IEnumerable<Cotizaciones> Consulta(int empresa, int monedaBase, int monedaDestino, int anio);
    }
}
