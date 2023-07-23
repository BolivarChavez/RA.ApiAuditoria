using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class AuditoriaTareas
    {
        public int at_empresa {get; set;}
        public int at_auditoria { get; set; }
        public int at_tarea { get; set; }
        public int at_oficina { get; set; }
        public string? at_asignacion { get; set; }
        public string? at_estado { get; set; }
        public string? at_usuario_creacion { get; set; }
        public DateTime at_fecha_creacion { get; set; }
        public string? at_usuario_actualizacion { get; set; }
        public DateTime at_fecha_actualizacion { get; set; }
    }
}
