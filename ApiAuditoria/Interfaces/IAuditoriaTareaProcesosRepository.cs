using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaTareaProcesosRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaTareaProcesos auditoriaTareaProcesos);

        IEnumerable<Retorno> Actualizacion(AuditoriaTareaProcesos auditoriaTareaProcesos);

        IEnumerable<AuditoriaTareaProcesos> Consulta(int empresa, int auditoria, int tarea);
    }
}
