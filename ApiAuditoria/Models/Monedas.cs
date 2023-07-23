using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class Monedas
    {
        public int mo_codigo {get; set;}
        public string? mo_descripcion { get; set; }
        public string? mo_estado { get; set; }
        public string? mo_usuario_creacion { get; set; }
        public DateTime mo_fecha_creacion { get; set; }
        public string? mo_usuario_actualizacion { get; set; }
        public DateTime mo_fecha_actualizacion { get; set; }
    }
}
