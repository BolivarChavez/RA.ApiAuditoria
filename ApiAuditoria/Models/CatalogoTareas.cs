using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class CatalogoTareas
    {
        public Int16 ct_empresa {get; set;}
        public Int16 ct_proceso { get; set; }
        public Int16 ct_codigo { get; set; }
        public string? ct_descripcion { get; set; }
        public string? ct_estado { get; set; }
        public string? ct_usuario_creacion { get; set; }
        public DateTime ct_fecha_creacion { get; set; }
        public string? ct_usuario_actualizacion { get; set; }
        public DateTime ct_fecha_actualizacion { get; set; }
    }
}
