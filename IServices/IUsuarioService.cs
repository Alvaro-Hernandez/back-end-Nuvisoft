using BackEnd_NuvisoftEducation.Models;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.IServices
{
    public interface IUsuarioService
    {
        tb_usuario AddUsuario(tb_usuario oUsuario);
        List<tb_usuario> GetUsuarioList();
        tb_usuario GetUsuarioId(int usuarioId);
        string DeleteUsuario(int usuarioId);
        tb_usuario UpdateRol(tb_usuario oUsuario);
    }
}
