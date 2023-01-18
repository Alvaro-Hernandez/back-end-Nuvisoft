using System;

namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_trabajo
    {
        public int codTrabajo { get; set; }
        public DateTime inicio { get; set; }
        public DateTime final { get; set; }
        public int codPlantilla { get; set; }
    }
}
