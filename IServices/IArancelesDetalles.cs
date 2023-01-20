using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IArancelesDetallesService
    {
        tba_detalles AddArancelDetalle(tba_detalles oArancelDetalle);
        List<tba_detalles> GetArancelesDetallesList();
        tba_detalles GetArancelDetalleId(int arancelDetallesId);
        string DeleteArancelDetalles(int arancelDetallesId);
        tba_detalles UpdateArancelDetalle(tba_detalles oArancelDetalle);
    }
}
