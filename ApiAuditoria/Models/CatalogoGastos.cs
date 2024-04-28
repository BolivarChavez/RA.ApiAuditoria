using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class CatalogoGastos
    {
        public Int16 cg_empresa {get; set;}
        public Int16 cg_codigo { get; set; }
        public string? cg_descripion { get; set; }
        public string? cg_estado { get; set; }
        public string? cg_usuario_creacion { get; set; }
        public DateTime cg_fecha_creacion { get; set; }
        public string? cg_usuario_actualizacion { get; set; }
        public DateTime cg_fecha_actualizacion { get; set; }
    }
}
