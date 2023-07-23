using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class AuditoriaDocumentoProcesos
    {
        public int ad_empresa { get; set; }
        public int ad_auditoria { get; set; }
        public int ad_tarea { get; set; }
        public int ad_codigo { get; set; }
        public int ad_secuencia { get; set; }
        public DateTime ad_fecha { get; set; }
        public string? ad_auditor { get; set; }
        public string? ad_responsable { get; set; }
        public string? ad_observaciones { get; set; }
        public string? ad_documento { get; set; }
        public string? ad_estado { get; set; }
        public string? ad_usuario_creacion { get; set; }
        public DateTime ad_fecha_creacion { get; set; }
        public string? ad_usuario_actualizacion { get; set; }
        public DateTime ad_fecha_actualizacion { get; set; }
    }
}
