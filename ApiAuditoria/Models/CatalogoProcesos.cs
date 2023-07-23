using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class CatalogoProcesos
    {
        public int cp_empresa {get; set;}
        public int cp_codigo { get; set; }
        public string? cp_descripcion { get; set; }
        public string? cp_estado { get; set; }
        public string? cp_usuario_creacion { get; set; }
        public DateTime cp_fecha_creacion { get; set; }
        public string? cp_usuario_actualizacion { get; set; }
        public DateTime cp_fecha_actualizacion { get; set; }
    }
}
