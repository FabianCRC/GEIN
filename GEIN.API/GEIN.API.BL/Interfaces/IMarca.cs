using GEIN.API.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEIN.API.BL.Interfaces
{
    public interface IMarca
    {
        public ICollection<Marca> GetAll();
        public Marca GetOneById(int id);
        public bool Add(Marca model);
        public bool Update(Marca model);
        public bool Delete(int id);
    }
}
