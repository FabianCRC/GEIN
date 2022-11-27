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
namespace GEIN.API.DAL
{
    public class Producto : ICRUD<data.Producto>
    {
        private Repository<data.Producto> _repo;

        public Producto(GEINContext geinContext)
        {
            _repo = new Repository<data.Producto>(geinContext);
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Producto GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Producto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Producto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public void Delete(data.Producto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }
    }
}
