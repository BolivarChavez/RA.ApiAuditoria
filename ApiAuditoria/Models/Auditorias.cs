using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class Auditorias
    {
        public Int16 au_empresa {get; set;}
        public int au_codigo { get; set; }
        public Int16 au_oficina_origen { get; set; }
        public Int16 au_oficina_destino { get; set; }
        public Int16 au_tipo_proceso { get; set; }
        public DateTime au_fecha_inicio { get; set; }
        public DateTime au_fecha_cierre { get; set; }
        public string? au_tipo { get; set; }
        public string? au_observaciones { get; set; }
        public string? au_estado { get; set; }
        public string? au_usuario_creacion { get; set; }
        public DateTime au_fecha_creacion { get; set; }
        public string? au_usuario_actualizacion { get; set; }
        public DateTime au_fecha_actualizacion { get; set; }
    }
}
