using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICatalogoProcesosRepository
    {
        IEnumerable<Retorno> Ingreso(CatalogoProcesos catalogoProcesos);

        IEnumerable<Retorno> Actualizacion(CatalogoProcesos catalogoProcesos);

        IEnumerable<CatalogoProcesos> Consulta(int empresa); 
    }
}
