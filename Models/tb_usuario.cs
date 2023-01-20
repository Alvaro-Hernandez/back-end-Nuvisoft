namespace BackEnd_NuvisoftEducation.Models
{
    public class tb_usuario
    {
        public int codUsuario { get; set; }
        public int codColegio { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string dni { get; set; }
        public string Error { get; set; }
    }
}
