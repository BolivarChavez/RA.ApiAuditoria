using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class AuditoriaAsignacion
    {
        public int aa_empresa {get; set;}
        public int aa_auditoria { get; set; }
        public int aa_tarea { get; set; }
        public int aa_secuencia { get; set; }
        public int aa_responsable { get; set; }
        public string? aa_tipo { get; set; }
        public string? aa_rol { get; set; }
        public string? aa_estado { get; set; }
        public string? aa_usuario_creacion { get; set; }
        public DateTime aa_fecha_creacion { get; set; }
        public string? aa_usuario_actualizacion { get; set; }
        public DateTime aa_fecha_actualizacion { get; set; }
    }
}
