using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> get();
        T getById(int id);
        void add(T entity);
        int update(T entity);
        int delete(int id);
    }
}
