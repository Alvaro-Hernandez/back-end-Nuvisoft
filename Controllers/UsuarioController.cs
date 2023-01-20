using BackEnd_NuvisoftEducation.IServices;
using BackEnd_NuvisoftEducation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace BackEnd_NuvisoftEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _oUsuarioService;

        public UsuarioController(IUsuarioService oUsuarioService)
        {
            _oUsuarioService = oUsuarioService;
        }

        // GET: api/<GetUsuarioList>
        [HttpGet(Name = "GetUsuarioList")]
        public IEnumerable<tb_usuario> GetUsuarioList()
        {
            return _oUsuarioService.GetUsuarioList();
        }

        // GET api/<GetUsuarioId>/5
        [HttpGet("{id}", Name = "GetUsuarioId")]
        public tb_usuario GetUsuarioId(int id)
        {
            return _oUsuarioService.GetUsuarioId(id);
        }

        // POST api/<PostUsuario>
        [HttpPost(Name = "PostUsuario")]
        public void PostUsuario([FromBody] tb_usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _oUsuarioService.AddUsuario(usuario);
            }
        }

        // PUT api/<PutUsuario>/5
        [HttpPut("{id}", Name = "PutUsuario")]
        public void PutUsuario([FromBody] tb_usuario usuarioUpdate)
        {
            if (ModelState.IsValid)
            {
                _oUsuarioService.UpdateUsuario(usuarioUpdate);
            }
        }

        // DELETE api/<DeleteUsuario>/5
        [HttpDelete("{id}", Name = "DeleteUsuario")]
        public void DeleteUsuario(int id)
        {
            if (id != 0)
            {
                _oUsuarioService.DeleteUsuario(id);
            }
        }
    }
}
