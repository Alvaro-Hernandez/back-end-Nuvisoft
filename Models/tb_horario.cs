namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_horario
    {
        public int codHorario { get; set; }
        public string nombre { get; set; }
        public modalidad modalidad { get; set; }
    }

    public enum modalidad
    {
        matutino,
        vespertino,
        nocturno,
        sabatino,
        dominical
    }
}
