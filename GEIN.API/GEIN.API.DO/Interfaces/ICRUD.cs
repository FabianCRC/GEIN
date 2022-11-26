using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.DO.Interfaces
{
    public interface ICRUD<T>
    { 
        IEnumerable<T> GetAll();
        T GetOneById(int id);
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
    }
}
