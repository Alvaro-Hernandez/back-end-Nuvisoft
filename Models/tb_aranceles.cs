namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_aranceles
    {
        public int codAranceles { get; set; }
        public int codUsuario { get; set; }
        public estado estado { get; set; }

    }

    public enum estado
    {
        pagado,
        adeudo
    }
}
