using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IPrivilegiosService
    {
        tb_privilegios AddPrivilegios(tb_privilegios oPrivilegios);
        List<tb_privilegios> GetPrivilegiosList();
        tb_privilegios GetPrivilegioId(int privilegioId);
        string DeletePrivilegios(int privilegioId);
        tb_privilegios UpdatePrivilegios(tb_privilegios oPrivilegios);
    }
}
