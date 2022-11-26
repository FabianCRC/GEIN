using GEIN.API.DAL.EF;
using GEIN.API.DAL.Repository;
using GEIN.API.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = GEIN.API.DO.Models;

namespace GEIN.API.DAL
{
    public class Marca : ICRUD<data.Marca>
    {
        private Repository<data.Marca> _repo;

        public Marca(GEINContext geinContext)
        {
            _repo = new Repository<data.Marca>(geinContext);
        }

        public IEnumerable<data.Marca> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Marca GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Marca t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Marca t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public void Delete(data.Marca t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

    }
}
