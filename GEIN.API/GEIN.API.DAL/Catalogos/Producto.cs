using GEIN.API.DAL.EF;
using GEIN.API.DAL.Repository;
using GEIN.API.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using data = GEIN.API.DO.Models;
namespace GEIN.API.DAL.Catalogos
{
    public class Producto : ICRUD<data.Catalogos.Producto>
    {
        private Repository<data.Catalogos.Producto> _repo;

        public Producto(GEINContext geinContext)
        {
            _repo = new Repository<data.Catalogos.Producto>(geinContext);
        }

        public IEnumerable<data.Catalogos.Producto> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Catalogos.Producto GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Catalogos.Producto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Catalogos.Producto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public void Delete(data.Catalogos.Producto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }
    }
}
