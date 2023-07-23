using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriasRepository
    {
        IEnumerable<Retorno> Ingreso(Auditorias auditoria);

        IEnumerable<Retorno> Actualizacion(Auditorias auditoria);

        IEnumerable<Auditorias> Consulta(int empresa, int codigo);
    }
}
