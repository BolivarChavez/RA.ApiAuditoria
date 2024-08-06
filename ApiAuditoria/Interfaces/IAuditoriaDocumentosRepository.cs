using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaDocumentosRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaDocumentos auditoriaDocumentos);

        IEnumerable<Retorno> Actualizacion(AuditoriaDocumentos auditoriaDocumentos);

        IEnumerable<AuditoriaDocumentos> Consulta(int empresa, int auditoria, int tarea, int plantilla, int anio);
    }
}
