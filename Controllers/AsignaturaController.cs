using BackEnd_NuvisoftEducation.IServices;
using BackEnd_NuvisoftEducation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private IAsignaturaService _oAsignaturaService;

        public AsignaturaController(IAsignaturaService oAsignaturaService)
        {
            _oAsignaturaService = oAsignaturaService;
        }

        // GET: api/<GetAsignaturaList>
        [HttpGet(Name = "GetAsignaturaList")]
        public IEnumerable<tb_asignatura> GetAsignaturaList()
        {
            return _oAsignaturaService.GetAsignaturasList();
        }

        // GET api/<GetAsignaturaId>/5
        [HttpGet("{id}", Name = "GetAsignaturaId")]
        public tb_asignatura GetAsignaturaId(int id)
        {
            return _oAsignaturaService.GetAsignaturaId(id);
        }

        // POST api/<PostAsignatura>
        [HttpPost(Name = "PostAsignatura")]
        public void PostAsignatura([FromBody] tb_asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _oAsignaturaService.AddAsignatura(asignatura);
            }
        }

        // PUT api/<PutAsignatura>/5
        [HttpPut("{id}", Name = "PutAsignatura")]
        public void PutAsignatura([FromBody] tb_asignatura asignaturaUpdate)
        {
            if (ModelState.IsValid)
            {
                _oAsignaturaService.UpdateAsignatura(asignaturaUpdate);
            }
        }

        // DELETE api/<DeleteAsignatura>/5
        [HttpDelete("{id}", Name = "DeleteAsignatura")]
        public void DeleteAsignatura(int id)
        {
            if (id != 0)
            {
                _oAsignaturaService.DeleteAsignatura(id);
            }
        }
    }
}
