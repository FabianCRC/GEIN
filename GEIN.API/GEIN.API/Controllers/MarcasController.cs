using GEIN.API.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<data.Marca> GetMarcas()
        {
            return new BL.Marca(_geinContext).GetAll();
        }


        [HttpGet("{id}")]
        public data.Marca GetMarca(int id)
        {
            return new BL.Marca(_geinContext).GetOneById(id); ;
        }


        [HttpPut("{id}")]
        public bool PutMarca(data.Marca model)
        {
            new BL.Marca(_geinContext).Update(model);
            return true;

        }


        [HttpPost]
        public bool PostMarca(data.Marca model)
        {
            new BL.Marca(_geinContext).Insert(model);
            return true;
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public  data.Marca DeleteMarca(int id)
        {
            return new BL.Marca(_geinContext).GetOneById(id);  
        }
         
    }
}
