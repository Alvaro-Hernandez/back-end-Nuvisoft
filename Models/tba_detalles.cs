using System;

namespace BackEnd_NuvisoftEducation.Models
{
    public class tba_detalles
    {
        public int codArancelesDetalles { get; set; }
        public int codAranceles { get; set; }
        public estadoD estado { get; set; }
        public DateTime vencimiento { get; set; }
        public Boolean cancelacion { get; set; }
        public string concepto { get; set; }
        public int monto { get; set; }
    }
    public enum estadoD
    {
        pagado,
        adeudo
    }
}
