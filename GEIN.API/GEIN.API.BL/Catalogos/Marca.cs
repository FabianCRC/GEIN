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
    public class Marca : ICRUD<data.Marca>
    {
        private GEINContext _geinContext;

        public Marca(GEINContext geinContext)
        {
            _geinContext = geinContext;
        }
        public IEnumerable<data.Marca> GetAll()
        {
            return new dal.Marca(_geinContext).GetAll();
        }

        public data.Marca GetOneById(int id)
        {
            return new dal.Marca(_geinContext).GetOneById(id);
        }

        public void Insert(data.Marca t)
        {
            new dal.Marca(_geinContext).Insert(t);
        }

        public void Update(data.Marca t)
        {
            new dal.Marca(_geinContext).Update(t);
        }
        public void Delete(data.Marca t)
        {
            new dal.Marca(_geinContext).Delete(t);
        }
    }
}
