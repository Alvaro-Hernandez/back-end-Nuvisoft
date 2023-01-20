using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IColegioService
    {
        tb_colegio AddColegio(tb_colegio oColegio);
        List<tb_colegio> GetColegioList();
        tb_colegio GetColegioId(int colegioId);
        string DeleteColegio(int colegioId);
        tb_colegio UpdateColegio(tb_colegio oColegio);
    }
}
