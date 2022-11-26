using GEIN.API.BL.Interfaces;
using GEIN.API.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.BL.Class
{
    public class MarcaBL : IMarca
    {
        GEINContext _geinContext;

        public MarcaBL(GEINContext geinContext)
        {
            this._geinContext = geinContext;
        }
        public ICollection<Marca> GetAll()
        {
            return _geinContext.Marcas.ToList();
        }

        public Marca GetOneById(int id)
        {
            return _geinContext.Marcas.Find(id);
        }
        public bool Add(Marca model)
        {
            _geinContext.Marcas.Add(model);
            _geinContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _geinContext.Marcas.Remove(_geinContext.Marcas.Find(id));
            _geinContext.SaveChanges();
            return true;
        }


        public bool Update(Marca model)
        {
            _geinContext.Update(model);
            _geinContext.SaveChanges();
            return true;
        }
    }
}
