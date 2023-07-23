using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaTareasRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaTareas auditoriaTarea);

        IEnumerable<Retorno> Actualizacion(AuditoriaTareas auditoriaTarea);

        IEnumerable<AuditoriaTareas> Consulta(int empresa, int auditoria, int tarea);
    }
}
