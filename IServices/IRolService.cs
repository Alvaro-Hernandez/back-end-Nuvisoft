using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IRolService
    {
        tb_rol AddRol(tb_rol oRol);
        List<tb_rol> GetRolList();
        tb_rol GetRolId(int rolId);
        string DeleteRol (int rolId);
        tb_rol UpdateRol(tb_rol oRol);
    }
}
