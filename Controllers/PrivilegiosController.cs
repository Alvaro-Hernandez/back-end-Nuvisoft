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
    public class PrivilegiosController : ControllerBase
    {
        private IPrivilegiosService _oPrivilegioService;

        public PrivilegiosController(IPrivilegiosService oPrivilegiosService)
        {
            _oPrivilegioService = oPrivilegiosService;
        }

        // GET: api/<GetPrivilegioList>
        [HttpGet(Name = "GetPrivilegioList")]
        public IEnumerable<tb_privilegios> GetPrivilegioList()
        {
            return _oPrivilegioService.GetPrivilegiosList();
        }

        // GET api/<GetPrivilegioId>/5
        [HttpGet("{id}", Name = "GetPrivilegioId")]
        public tb_privilegios GetPrivilegioId(int id)
        {
            return _oPrivilegioService.GetPrivilegioId(id);
        }

        // POST api/<PostPrivilegios>
        [HttpPost(Name = "PostPrivilegios")]
        public void PostPrivilegios([FromBody] tb_privilegios privilegios)
        {
            if (ModelState.IsValid)
            {
                _oPrivilegioService.AddPrivilegios(privilegios);
            }
        }

        // PUT api/<PutPrivilegio>/5
        [HttpPut("{id}", Name = "PutPrivilegio")]
        public void PutPrivilegio([FromBody] tb_privilegios privilegioUpdate)
        {
            if (ModelState.IsValid)
            {
                _oPrivilegioService.UpdatePrivilegios(privilegioUpdate);
            }
        }

        // DELETE api/<DeletePrivilegio>/5
        [HttpDelete("{id}", Name = "DeletePrivilegio")]
        public void DeletePrivilegio(int id)
        {
            if (id != 0)
            {
                _oPrivilegioService.DeletePrivilegios(id);
            }
        }
    }
}
