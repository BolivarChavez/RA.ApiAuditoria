using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class Responsables
    {
        public Int16 re_empresa {get; set;}
        public Int16 re_codigo { get; set; }
        public string? re_nombre { get; set; }
        public string? re_cargo { get; set; }
        public Int16 re_oficina { get; set; }
        public string? re_tipo { get; set; }
        public string? re_correo { get; set; }
        public string? re_usuario { get; set; }
        public string? re_estado { get; set; }
        public string? re_usuario_creacion { get; set; }
        public DateTime re_fecha_creacion { get; set; }
        public string? re_usuario_actualizacion { get; set; }
        public DateTime re_fecha_actualizacion { get; set; }
    }
}
