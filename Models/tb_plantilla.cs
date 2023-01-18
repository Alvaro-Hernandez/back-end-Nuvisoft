namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_plantilla
    {
        public int codPlantilla { get; set; }
        public string titulo { get; set; }
        public tipo tipo { get; set; }
        public string descripcion { get; set; }
    }

    public enum tipo
    {
        examen,
        sistematico,
        trabajo
    }
}
