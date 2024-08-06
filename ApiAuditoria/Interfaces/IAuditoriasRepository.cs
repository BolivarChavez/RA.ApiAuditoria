using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriasRepository
    {
        IEnumerable<Retorno> Ingreso(Auditorias auditoria);

        IEnumerable<Retorno> Actualizacion(Auditorias auditoria);

        IEnumerable<Auditorias> Consulta(int empresa, int codigo, int anio);

        IEnumerable<Auditorias> ConsultaPlantilla(int empresa, int codigo, int anio, int plantilla);

        IEnumerable<AuditoriaResumen> ConsultaResumen(int empresa, int anio);

        IEnumerable<Retorno> CopiaAuditoria(Auditorias auditoria);
    }
}
