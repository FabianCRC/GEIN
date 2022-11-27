using GEIN.API.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BL = GEIN.API.BL;
using data = GEIN.API.DO.Models;

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {

        private readonly GEINContext _geinContext;
        public ProductosController(GEINContext geinContext)
        {
            this._geinContext = geinContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Producto>>> GetProductos()
        {
            return new BL.Producto(_geinContext).GetAll().ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<data.Producto>> GetProducto(int id)
        {
            return new BL.Producto(_geinContext).GetOneById(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, data.Producto model)
        {
            if (id != model.IdProducto)
            {
                return BadRequest();
            }
            new BL.Producto(_geinContext).Update(model);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<data.Producto>> PostProducto(int id, data.Producto model)
        {
            new BL.Producto(_geinContext).Insert(model);
            return NoContent();
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Producto>> DeleteProducto(int id)
        {
            var Producto = new BL.Producto(_geinContext).GetOneById(id);
            if (Producto == null)
            {
                return NotFound();
            }
            new BL.Producto(_geinContext).Delete(Producto);
            return Producto;
        }
    }
}
