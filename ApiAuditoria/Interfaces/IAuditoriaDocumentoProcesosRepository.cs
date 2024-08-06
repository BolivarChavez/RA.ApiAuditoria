using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaDocumentoProcesosRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaDocumentoProcesos auditoriaDocumentoProceso);

        IEnumerable<Retorno> Actualizacion(AuditoriaDocumentoProcesos auditoriaDocumentoProceso);

        IEnumerable<AuditoriaDocumentoProcesos> Consulta(int empresa, int auditoria, int tarea, int codigo, int anio);
    }
}
