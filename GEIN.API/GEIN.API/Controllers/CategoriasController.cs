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
    public class CategoriasController : Controller
    {
        private readonly GEINContext _geinContext;
        private readonly IMapper _mapper;
        public CategoriasController(GEINContext geinContext, IMapper mapper)
        {
            this._geinContext = geinContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodel.Categoria>>> GetCategorias()
        {
            var aux = new BL.Categoria(_geinContext).GetAll().ToList();
            return _mapper.Map<IEnumerable<data.Categoria>, IEnumerable<datamodel.Categoria>>(aux).ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<datamodel.Categoria>> GetCategoria(int id)
        {
            var aux = new BL.Categoria(_geinContext).GetOneById(id);
            return _mapper.Map<data.Categoria, datamodel.Categoria>(aux);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, datamodel.Categoria model)
        {
            if (id != model.IdCategoria)
            {
                return BadRequest();
            }
            var mapaux = _mapper.Map<datamodel.Categoria, data.Categoria>(model);
            new BL.Categoria(_geinContext).Update(mapaux);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostCategoria(datamodel.Categoria model)
        {
            var mapaux = _mapper.Map<datamodel.Categoria, data.Categoria>(model);
            new BL.Categoria(_geinContext).Insert(mapaux);
            return NoContent();
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodel.Categoria>> DeleteCategoria(int id)
        {
            var categoria = new BL.Categoria(_geinContext).GetOneById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            new BL.Categoria(_geinContext).Delete(categoria);
            var aux = _mapper.Map<data.Categoria, datamodel.Categoria>(categoria);
            return aux;
        }
    }
}
