using ApiAuditoria.Models;

namespace ApiAuditoria.Interfaces
{
    public interface ICatalogoPlantillasRepository
    {
        IEnumerable<Retorno> Ingreso(CatalogoPlantillas catalogoPlantillas);

        IEnumerable<Retorno> Actualizacion(CatalogoPlantillas catalogoPlantillas);

        IEnumerable<CatalogoPlantillas> Consulta(int empresa);
    }
}
