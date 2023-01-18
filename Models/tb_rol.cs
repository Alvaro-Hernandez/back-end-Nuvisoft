namespace BackEnd_NuvisoftEducation.Models
{

    public class tb_rol
    {
        public int codRol { get; set; }
        public tipoRol rol { get; set; }
    }
    public enum tipoRol
    {
        administrador,
        docente,
        estudiante
    }
}
