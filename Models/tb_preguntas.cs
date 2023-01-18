using System;

namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_preguntas
    {
        public int codPregunta { get; set; }
        public string titulo { get; set; }
        public string tipo { get; set; }
        public int puntaje { get; set; }
        public Boolean autoContestado { get; set; }
        public int codPlantilla { get; set; }

    }
}
