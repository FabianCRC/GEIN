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
    public class Producto : ICRUD<data.Producto>
    {
        private GEINContext _geinContext;

        public Producto(GEINContext geinContext)
        {
            _geinContext = geinContext;
        }
        public IEnumerable<data.Producto> GetAll()
        {
            return new dal.Producto(_geinContext).GetAll();
        }

        public data.Producto GetOneById(int id)
        {
            return new dal.Producto(_geinContext).GetOneById(id);
        }

        public void Insert(data.Producto t)
        {
            new dal.Producto(_geinContext).Insert(t);
        }

        public void Update(data.Producto t)
        {
            new dal.Producto(_geinContext).Update(t);
        }
        public void Delete(data.Producto t)
        {
            new dal.Producto(_geinContext).Delete(t);
        }
    }
}
