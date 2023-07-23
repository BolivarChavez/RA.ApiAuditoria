using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICatalogoGastosRepository
    {
        IEnumerable<Retorno> Ingreso(CatalogoGastos catalogoGastos);

        IEnumerable<Retorno> Actualizacion(CatalogoGastos catalogoGastos);

        IEnumerable<CatalogoGastos> Consulta(int empresa);
    }
}
