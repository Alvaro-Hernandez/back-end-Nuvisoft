using BackEnd_NuvisoftEducation.IServices;
using BackEnd_NuvisoftEducation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd_NuvisoftEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArancelDetallesController : ControllerBase
    {
        private IArancelesDetallesService _oArancelesDetallesService;

        public ArancelDetallesController(IArancelesDetallesService oArancelesDetallesService)
        {
            _oArancelesDetallesService = oArancelesDetallesService;
        }

        // GET: api/<GetArancelesDetallesList>
        [HttpGet(Name = "GetArancelesDetallesList")]
        public IEnumerable<tba_detalles> GetArancelesDetallesList()
        {
            return _oArancelesDetallesService.GetArancelesDetallesList();
        }

        // GET api/<GetArancelDetalleId>/5
        [HttpGet("{id}", Name = "GetArancelDetalleId")]
        public tba_detalles GetArancelDetalleId(int id)
        {
            return _oArancelesDetallesService.GetArancelDetalleId(id);
        }

        // POST api/<PostArancelDetalle>
        [HttpPost(Name = "PostArancelDetalle")]
        public void PostArancelDetalle([FromBody] tba_detalles arancelesDetalles)
        {
            if (ModelState.IsValid)
            {
                _oArancelesDetallesService.AddArancelDetalle(arancelesDetalles);
            }
        }

        // PUT api/<PutArancelDetalle>/5
        [HttpPut("{id}", Name = "PutArancelDetalle")]
        public void PutArancelDetalle([FromBody] tba_detalles arancelDetalleUpdate)
        {
            if (ModelState.IsValid)
            {
                _oArancelesDetallesService.UpdateArancelDetalle(arancelDetalleUpdate);
            }
        }

        // DELETE api/<DeleteArancelDetalle>/5
        [HttpDelete("{id}", Name = "DeleteArancelDetalle")]
        public void DeleteArancelDetalle(int id)
        {
            if (id != 0)
            {
                _oArancelesDetallesService.DeleteArancelDetalles(id);
            }
        }
    }
}
