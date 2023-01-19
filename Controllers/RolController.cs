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
    public class RolController : ControllerBase
    {
        private IRolService _oRolService;

        public RolController(IRolService oRolService)
        {
            _oRolService = oRolService;
        }

        // GET: api/<GetRolList>
        [HttpGet(Name = "GetRolList")]
        public IEnumerable<tb_rol> GetRolList()
        {
            return _oRolService.GetRolList();
        }

        // GET api/<GetRolId>/5
        [HttpGet("{id}", Name ="GetRolId")]
        public tb_rol GetRolId(int id)
        {
            return _oRolService.GetRolId(id);
        }

        // POST api/<PostRol>
        [HttpPost(Name = "PostRol")]
        public void PostRol([FromBody] tb_rol rol)
        {
            if (ModelState.IsValid)
            {
                _oRolService.AddRol(rol);
            }
        }

        // PUT api/<PutRol>/5
        [HttpPut("{id}", Name ="PutRol")]
        public void PutRol([FromBody] tb_rol rolUpdate)
        {
            if (ModelState.IsValid)
            {
                _oRolService.UpdateRol(rolUpdate);
            }
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}", Name ="DeleteRol")]
        public void DeleteRol(int id)
        {
            if(id != 0)
            {
                _oRolService.DeleteRol(id);
            }
        }
    }
}
