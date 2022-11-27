using GEIN.API.DAL.EF;
using GEIN.API.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using data = GEIN.API.DO.Models;

namespace GEIN.API.BL
{
    public class Categoria : ICRUD<data.Categoria>
    {
        private GEINContext _geinContext;

        public Categoria(GEINContext geinContext)
        {
            _geinContext = geinContext;
        }
        public IEnumerable<data.Categoria> GetAll()
        {
            return new DAL.Categoria(_geinContext).GetAll();
        }

        public data.Categoria GetOneById(int id)
        {
            return new DAL.Categoria(_geinContext).GetOneById(id);
        }

        public void Insert(data.Categoria t)
        {
            new DAL.Categoria(_geinContext).Insert(t);
        }

        public void Update(data.Categoria t)
        {
            new DAL.Categoria(_geinContext).Update(t);
        }
        public void Delete(data.Categoria t)
        {
            new DAL.Categoria(_geinContext).Delete(t);
        }
    }
}
