using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICategoriaGastosRepository
    {
        IEnumerable<Retorno> Ingreso(CategoriaGastos categoriaGastos);

        IEnumerable<Retorno> Actualizacion(CategoriaGastos categoriaGastos);

        IEnumerable<CategoriaGastos> Consulta(int empresa);
    }
}
