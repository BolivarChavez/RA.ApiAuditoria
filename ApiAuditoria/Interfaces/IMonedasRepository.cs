using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IMonedasRepository
    {
        IEnumerable<Retorno> Ingreso(Monedas monedas);

        IEnumerable<Retorno> Actualizacion(Monedas monedas);

        IEnumerable<Monedas> Consulta(int codigo);
    }
}
