using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class AuditoriaTareaProcesos
    {
        public int at_empresa {get; set;}
        public int at_auditoria { get; set; }
        public int at_tarea { get; set; }
        public int at_secuencia { get; set; }
        public int at_auditor { get; set; }
        public int at_responsable { get; set; }
        public DateTime at_fecha { get; set; }
        public string? at_observaciones { get; set; }
        public string? at_estado { get; set; }
        public string? at_usuario_creacion { get; set; }
        public DateTime at_fecha_creacion { get; set; }
        public string? at_usuario_actualizacion { get; set; }
        public DateTime at_fecha_actualizacion { get; set; }
    }
}
