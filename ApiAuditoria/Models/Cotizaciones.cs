using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Models
{
    [Keyless]
    public class Cotizaciones
    {
        public int co_empresa {get; set;}
        public int co_moneda_base { get; set; }
        public int co_moneda_destino { get; set; }
        public double co_cotizacion { get; set; }
        public DateTime co_fecha_vigencia { get; set; }
        public string? co_estado { get; set; }
        public string? co_usuario_creacion { get; set; }
        public DateTime co_fecha_creacion { get; set; }
        public string? co_usurio_actualizacion { get; set; }
        public DateTime co_fecha_actualizacion { get; set; }
    }
}
