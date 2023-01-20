using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IArancelesService
    {
        tb_aranceles AddArancel(tb_aranceles oArancel);
        List<tb_aranceles> GetArancelesList();
        tb_aranceles GetArancelId(int arancelId);
        string DeleteArancel(int arancelId);
        tb_aranceles UpdateArancel(tb_aranceles oArancel);
    }
}
