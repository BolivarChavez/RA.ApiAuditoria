using ApiAuditoria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAuditoria.Gateways.DataContext
{
    public class ApiAuditoriaContext : DbContext
    {
        public ApiAuditoriaContext(DbContextOptions<ApiAuditoriaContext> options) : base(options) { }

        public DbSet<AuditoriaAsignacion> AuditoriaAsignacion { get; set; }
        public DbSet<AuditoriaDocumentoProcesos> AuditoriaDocumentoProcesos { get; set; }
        public DbSet<AuditoriaDocumentos> AuditoriaDocumentos { get; set; }
        public DbSet<AuditoriaGastos> AuditoriaGastos { get; set; }
        public DbSet<Auditorias> Auditorias { get; set; }
        public DbSet<AuditoriaTareaProcesos> AuditoriaTareaProcesos { get; set; }
        public DbSet<AuditoriaTareas> AuditoriaTareas { get; set; }
        public DbSet<CatalogoGastos> CatalogoGastos { get; set; }
        public DbSet<CatalogoPlantillas> CatalogoPlantillas { get; set; }
        public DbSet<CatalogoProcesos> CatalogoProcesos { get; set; }
        public DbSet<CatalogoTareas> CatalogoTareas { get; set; }
        public DbSet<Cotizaciones> Cotizaciones { get; set; }
        public DbSet<Monedas> Monedas { get; set; }
        public DbSet<Responsables> Responsables { get; set; }
        public DbSet<Retorno> Retorno { get; set; }
    }
}
