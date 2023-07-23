using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface IAuditoriaGastosRepository
    {
        IEnumerable<Retorno> Ingreso(AuditoriaGastos auditoriaGastos);

        IEnumerable<Retorno> Actualizacion(AuditoriaGastos auditoriaGastos);

        IEnumerable<AuditoriaGastos> Consulta(int empresa, int auditoria);
    }
}
