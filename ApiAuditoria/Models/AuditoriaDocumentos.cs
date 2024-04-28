using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class AuditoriaDocumentos
    {
        public Int16 ad_empresa {get; set;}
        public int ad_auditoria { get; set; }
        public Int16 ad_tarea { get; set; }
        public Int16 ad_codigo { get; set; }
        public Int16 ad_plantilla { get; set; }
        public string? ad_referencia { get; set; }
        public string? ad_registro { get; set; }
        public int ad_auditoria_origen { get; set; }
        public Int16 ad_responsable { get; set; }
        public string? ad_estado { get; set; }
        public string? ad_usuario_creacion { get; set; }
        public DateTime ad_fecha_creacion { get; set; }
        public string? ad_usuario_actualizacion { get; set; }
        public DateTime ad_fecha_actualizacion { get; set; }
    }
}
