using GEIN.API.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BL = GEIN.API.BL;
using data = GEIN.API.DO.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly GEINContext _geinContext;
        public MarcasController(GEINContext geinContext)
        {
            this._geinContext = geinContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Marca>>> GetMarcas()
        {
            return new BL.Marca(_geinContext).GetAll().ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<data.Marca>> GetMarca(int id)
        {
            return new BL.Marca(_geinContext).GetOneById(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, data.Marca model)
        {
            if (id != model.IdMarca)
            {
                return BadRequest();
            }
            new BL.Marca(_geinContext).Update(model);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<data.Marca>> PostMarca(int id, data.Marca model)
        {
            new BL.Marca(_geinContext).Insert(model);
            return NoContent();
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Marca>> DeleteMarca(int id)
        {
            var marca = new BL.Marca(_geinContext).GetOneById(id);
            if (marca == null)
            {
                return NotFound();
            }
            new BL.Marca(_geinContext).Delete(marca);
            return marca;
        }

    }
}
