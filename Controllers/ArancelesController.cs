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
    public class ArancelesController : ControllerBase
    {
        private IArancelesService _oArancelesService;

        public ArancelesController(IArancelesService oArancelesService)
        {
            _oArancelesService = oArancelesService;
        }

        // GET: api/<GetArancelesList>
        [HttpGet(Name = "GetArancelesList")]
        public IEnumerable<tb_aranceles> GetArancelesList()
        {
            return _oArancelesService.GetArancelesList();
        }

        // GET api/<GetArancelId>/5
        [HttpGet("{id}", Name = "GetArancelId")]
        public tb_aranceles GetArancelId(int id)
        {
            return _oArancelesService.GetArancelId(id);
        }

        // POST api/<PostArancel>
        [HttpPost(Name = "PostArancel")]
        public void PostArancel([FromBody] tb_aranceles aranceles)
        {
            if (ModelState.IsValid)
            {
                _oArancelesService.AddArancel(aranceles);
            }
        }

        // PUT api/<PutArancel>/5
        [HttpPut("{id}", Name = "PutArancel")]
        public void PutArancel([FromBody] tb_aranceles arancelUpdate)
        {
            if (ModelState.IsValid)
            {
                _oArancelesService.UpdateArancel(arancelUpdate);
            }
        }

        // DELETE api/<DeleteArancel>/5
        [HttpDelete("{id}", Name = "DeleteArancel")]
        public void DeleteArancel(int id)
        {
            if (id != 0)
            {
                _oArancelesService.DeleteArancel(id);
            }
        }
    }
}
