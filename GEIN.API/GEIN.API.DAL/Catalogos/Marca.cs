using GEIN.API.DAL.EF;
using GEIN.API.DAL.Repository;
using GEIN.API.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = GEIN.API.DO.Models;

namespace GEIN.API.DAL.Catalogos
{
    public class Marca : ICRUD<data.Catalogos.Marca>
    {
        private Repository<data.Catalogos.Marca> _repo;

        public Marca(GEINContext geinContext)
        {
            _repo = new Repository<data.Catalogos.Marca>(geinContext);
        }

        public IEnumerable<data.Catalogos.Marca> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Catalogos.Marca GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Catalogos.Marca t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Catalogos.Marca t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public void Delete(data.Catalogos.Marca t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

    }
}
