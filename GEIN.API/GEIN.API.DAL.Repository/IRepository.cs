using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DAL.Repository
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        T GetOneById(int id);
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        void Commit();

        //De momento no tengo pensado utilizarlos pero los dejo pensando a futuro
        //IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
        //T GetOne(Expression<Func<T, bool>> predicado);
        //IQueryable<T> AsQueryble();
        //void AddRange(IEnumerable<T> t);
        //void UpdateRange(IEnumerable<T> t);
        //void RemoveRange(IEnumerable<T> t);
    }
}
