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
    public class ColegioController : ControllerBase
    {
        private IColegioService _oColegioService;

        public ColegioController(IColegioService oColegioService)
        {
            _oColegioService = oColegioService;
        }

        // GET: api/<GetColegioList>
        [HttpGet(Name = "GetColegioList")]
        public IEnumerable<tb_colegio> GetColegioList()
        {
            return _oColegioService.GetColegioList();
        }

        // GET api/<GetColegioId>/5
        [HttpGet("{id}", Name = "GetColegioId")]
        public tb_colegio GetColegioId(int id)
        {
            return _oColegioService.GetColegioId(id);
        }

        // POST api/<PostColegio>
        [HttpPost(Name = "PostColegio")]
        public void PostColegio([FromBody] tb_colegio colegio)
        {
            if (ModelState.IsValid)
            {
                _oColegioService.AddColegio(colegio);
            }
        }

        // PUT api/<PutColegio>/5
        [HttpPut("{id}", Name = "PutColegio")]
        public void PutColegio([FromBody] tb_colegio colegioUpdate)
        {
            if (ModelState.IsValid)
            {
                _oColegioService.UpdateColegio(colegioUpdate);
            }
        }

        // DELETE api/<DeleteColegio>/5
        [HttpDelete("{id}", Name = "DeleteColegio")]
        public void DeleteColegio(int id)
        {
            if (id != 0)
            {
                _oColegioService.DeleteColegio(id);
            }
        }
    }
}
