using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaAsignacionRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaAsignacion asignacionAuditoria);

        IEnumerable<Retorno> Actualizacion(AuditoriaAsignacion asignacionAuditoria);

        IEnumerable<AuditoriaAsignacion> Consulta(int empresa, int auditoria, int tarea);
    }
}
