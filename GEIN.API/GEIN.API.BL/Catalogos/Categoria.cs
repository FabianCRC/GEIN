using GEIN.API.DAL.EF;
using GEIN.API.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = GEIN.API.DAL.Catalogos;
using data = GEIN.API.DO.Models.Catalogos;

namespace GEIN.API.BL.Catalogos
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
            return new dal.Categoria(_geinContext).GetAll();
        }

        public data.Categoria GetOneById(int id)
        {
            return new dal.Categoria(_geinContext).GetOneById(id);
        }

        public void Insert(data.Categoria t)
        {
            new dal.Categoria(_geinContext).Insert(t);
        }

        public void Update(data.Categoria t)
        {
            new dal.Categoria(_geinContext).Update(t);
        }
        public void Delete(data.Categoria t)
        {
            new dal.Categoria(_geinContext).Delete(t);
        }
    }
}
