using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IResponsablesRepository
    {
        IEnumerable<Retorno> Ingreso(Responsables responsables);

        IEnumerable<Retorno> Actualizacion(Responsables responsables);

        IEnumerable<Responsables> Consulta(int codigo);
    }
}
