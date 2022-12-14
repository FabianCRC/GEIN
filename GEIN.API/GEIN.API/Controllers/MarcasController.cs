using AutoMapper;
using GEIN.API.DAL.EF;
using GEIN.API.DataModels.Catalogos;
using GEIN.API.DO.Models.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using bl = GEIN.API.BL.Catalogos;
using data = GEIN.API.DO.Models.Catalogos;
using datamodel = GEIN.API.DataModels.Catalogos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly GEINContext _geinContext;
        private readonly IMapper _mapper;
        public MarcasController(GEINContext geinContext, IMapper mapper)
        {
            this._geinContext = geinContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodel.Marca>>> GetMarcas()
        {
            var aux = new bl.Marca(_geinContext).GetAll().ToList();
            return _mapper.Map<IEnumerable<data.Marca>, IEnumerable<datamodel.Marca>>(aux).ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<datamodel.Marca>> GetMarca(int id)
        {
            var aux = new bl.Marca(_geinContext).GetOneById(id);
            return _mapper.Map<data.Marca, datamodel.Marca>(aux);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, datamodel.Marca model)
        {
            if (id != model.IdMarca)
            {
                return BadRequest();
            }
            var mapaux = _mapper.Map<datamodel.Marca, data.Marca>(model);
            new bl.Marca(_geinContext).Update(mapaux);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostMarca(datamodel.Marca model)
        {
            var mapaux = _mapper.Map<datamodel.Marca, data.Marca>(model);
            new bl.Marca(_geinContext).Insert(mapaux);
            return NoContent();
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodel.Marca>> DeleteMarca(int id)
        {
            var marca = new bl.Marca(_geinContext).GetOneById(id);
            if (marca == null)
            {
                return NotFound();
            }
            new bl.Marca(_geinContext).Delete(marca);
            var aux = _mapper.Map<data.Marca, datamodel.Marca>(marca);
            return aux;
        }

    }
}
