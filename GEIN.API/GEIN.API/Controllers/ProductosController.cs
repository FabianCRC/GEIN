using AutoMapper;
using GEIN.API.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BL = GEIN.API.BL;
using data = GEIN.API.DO.Models;
using datamodel = GEIN.API.DataModels;

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {

        private readonly GEINContext _geinContext;
        private readonly IMapper _mapper;
        public ProductosController(GEINContext geinContext, IMapper mapper)
        {
            this._geinContext = geinContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodel.Producto>>> GetProductos()
        {
            var aux = new BL.Producto(_geinContext).GetAll().ToList();
            return _mapper.Map<IEnumerable<data.Producto>, IEnumerable<datamodel.Producto>>(aux).ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<datamodel.Producto>> GetProducto(int id)
        {
            var aux = new BL.Producto(_geinContext).GetOneById(id);
            return _mapper.Map<data.Producto, datamodel.Producto>(aux);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, datamodel.Producto model)
        {
            if (id != model.IdProducto)
            {
                return BadRequest();
            }
            var mapaux = _mapper.Map<datamodel.Producto, data.Producto>(model);
            new BL.Producto(_geinContext).Update(mapaux);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostProducto(datamodel.Producto model)
        {
            var mapaux = _mapper.Map<datamodel.Producto, data.Producto>(model);
            new BL.Producto(_geinContext).Insert(mapaux);
            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodel.Producto>> DeleteProducto(int id)
        {
            var producto = new BL.Producto(_geinContext).GetOneById(id);
            if (producto == null)
            {
                return NotFound();
            }
            new BL.Producto(_geinContext).Delete(producto);
            var aux = _mapper.Map<data.Producto, datamodel.Producto>(producto);
            return aux;
        }
    }
}
