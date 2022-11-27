using GEIN.API.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BL = GEIN.API.BL;
using data = GEIN.API.DO.Models;

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly GEINContext _geinContext;
        public CategoriasController(GEINContext geinContext)
        {
            this._geinContext = geinContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Categoria>>> GetCategorias()
        {
            return new BL.Categoria(_geinContext).GetAll().ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<data.Categoria>> GetCategoria(int id)
        {
            return new BL.Categoria(_geinContext).GetOneById(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, data.Categoria model)
        {
            if (id != model.IdCategoria)
            {
                return BadRequest();
            }
            new BL.Categoria(_geinContext).Update(model);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<data.Categoria>> PostCategoria(int id, data.Categoria model)
        {
            new BL.Categoria(_geinContext).Insert(model);
            return NoContent();
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Categoria>> DeleteCategoria(int id)
        {
            var Categoria = new BL.Categoria(_geinContext).GetOneById(id);
            if (Categoria == null)
            {
                return NotFound();
            }
            new BL.Categoria(_geinContext).Delete(Categoria);
            return Categoria;
        }
    }
}
