using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class CatalogoTareas
    {
        public int ct_empresa {get; set;}
        public int ct_proceso { get; set; }
        public int ct_codigo { get; set; }
        public string? ct_descripcion { get; set; }
        public string? ct_estado { get; set; }
        public string? ct_usuario_creacion { get; set; }
        public DateTime ct_fecha_creacion { get; set; }
        public string? ct_usuario_actualizacion { get; set; }
        public DateTime ct_fecha_actualizacion { get; set; }
    }
}
