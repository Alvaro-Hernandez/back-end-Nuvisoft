using System;

namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_respuesta
    {
        public int codRespuesta { get; set; }
        public string descripcion { get; set; }
        public Boolean correcta { get; set; }
        public int codPregunta { get; set; }
    }
}
