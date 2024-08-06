namespace ApiAuditoria.Models
{
    public class AuditoriaResumen
    {
		public int Id { get; set; }
        public string? Proceso { get; set; }
        public string? Auditoria { get; set; }
        public string? EstadoAuditoria { get; set; }
        public string? OficinaOrigen { get; set; }
        public string? OficinaDestino { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaCierre { get; set; }
        public double Gastos { get; set; }
        public string? Tarea { get; set; }
        public string? Asignacion { get; set; }
        public string? Responsables { get; set; }
        public Int16 ProcesosActivos { get; set; }
        public Int16 ProcesosCerrados { get; set; }
        public Int16 PlantillasActivas { get; set; }
        public Int16 PlantillasProcesadas { get; set; }
        public string? EstadoTarea { get; set; }
    }
}
