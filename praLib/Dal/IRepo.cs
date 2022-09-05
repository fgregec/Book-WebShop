using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Dal
{
    public interface IRepo<T> where T : class
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        T Get(int id);
        IList<T> GetAll();
    }
}
