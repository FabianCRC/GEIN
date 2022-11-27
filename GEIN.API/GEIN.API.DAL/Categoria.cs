﻿using GEIN.API.DAL.EF;
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
    public class Categoria : ICRUD<data.Categoria>
    {
        private Repository<data.Categoria> _repo;

        public Categoria(GEINContext geinContext)
        {
            _repo = new Repository<data.Categoria>(geinContext);
        }

        public IEnumerable<data.Categoria> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Categoria GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Categoria t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Categoria t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public void Delete(data.Categoria t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }
    }
}
