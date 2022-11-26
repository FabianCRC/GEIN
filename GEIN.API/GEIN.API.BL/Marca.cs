using GEIN.API.DAL.EF;
using GEIN.API.DO.Interfaces;
using GEIN.API.DO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = GEIN.API.DO.Models;


namespace GEIN.API.BL
{
    public class Marca : ICRUD<data.Marca>
    {
        private GEINContext _geinContext;

        public Marca(GEINContext geinContext)
        {
            _geinContext = geinContext;
        }
        public IEnumerable<data.Marca> GetAll()
        {
            return new DAL.Marca(_geinContext).GetAll();
        }

        public data.Marca GetOneById(int id)
        {
            return new DAL.Marca(_geinContext).GetOneById(id);
        }

        public void Insert(data.Marca t)
        {
            new DAL.Marca(_geinContext).Insert(t);
        }

        public void Update(data.Marca t)
        {
            new DAL.Marca(_geinContext).Update(t);
        }
        public void Delete(data.Marca t)
        {
            new DAL.Marca(_geinContext).Delete(t);
        }
    }
}
