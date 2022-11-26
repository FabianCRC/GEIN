using GEIN.API.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly GEINContext _geinContext;
        public Repository(GEINContext geinContext)
        {
            this._geinContext = geinContext;
        }
        public IEnumerable<T> GetAll()
        {
            return _geinContext.Set<T>().ToList();
        }
        public T GetOneById(int id)
        {
            return _geinContext.Set<T>().Find(id);
        }
        public void Insert(T t)
        {
            try
            {
                if (_geinContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    _geinContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    _geinContext.Set<T>().Add(t);
                }
            }
            catch (Exception ee)
            {
                //Falta Control de excepciones
            }
        }
        public void Update(T t)
        {
            try
            {
                if (_geinContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    _geinContext.Set<T>().Attach(t);
                }
                _geinContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception ex)
            {
                //Falta Control de excepciones
            }
        }
        public void Delete(T t)
        {
            try
            {
                _geinContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ex)
            {
                //Falta Control de excepciones
            }
        }
        public void Commit()
        {
            _geinContext.SaveChanges();
        }

    }
}
