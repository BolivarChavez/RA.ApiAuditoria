using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICatalogoTareasRepository
    {
        IEnumerable<Retorno> Ingreso(CatalogoTareas catalogoTareas);

        IEnumerable<Retorno> Actualizacion(CatalogoTareas catalogoTareas);

        IEnumerable<CatalogoTareas> Consulta(int empresa);
    }
}
