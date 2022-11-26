using GEIN.API.BL.Class;
using GEIN.API.BL.Interfaces;
using GEIN.API.DA.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GEIN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        IMarca marcasBL;

        public MarcasController(GEINContext geinContext)
        {
            this.marcasBL = new MarcaBL(geinContext);
        }


        // GET: api/<MarcasController>
        [HttpGet]
        public IEnumerable<Marca> GetAll()
        {
            return marcasBL.GetAll();
        }

        // GET api/<MarcasController>/5
        [HttpGet("{id}")]
        public Marca GetOneById(int id)
        {
            return marcasBL.GetOneById(id);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public bool Add(Marca marca)
        {
            return marcasBL.Add(marca);
        }

        // PUT api/<MarcasController>/5
        [HttpPut("{id}")]
        public bool Update(Marca marca)
        {
            return marcasBL.Update(marca);
        }

        // DELETE api/<MarcasController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return marcasBL.Delete(id);
        }
    }
}
