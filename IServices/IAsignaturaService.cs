using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IAsignaturaService
    {
        tb_asignatura AddAsignatura(tb_asignatura oAsignatura);
        List<tb_asignatura> GetAsignaturasList();
        tb_asignatura GetAsignaturaId(int asignaturaId);
        string DeleteAsignatura(int asignaturaId);
        tb_asignatura UpdateAsignatura(tb_asignatura oAsignatura);
    }
}
