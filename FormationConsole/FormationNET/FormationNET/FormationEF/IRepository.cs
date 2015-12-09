using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public interface IRepository <T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByLambda(Func<T, bool> where, int page, int nbRow);
        T Insert(T entity);
        void Remove(T entity);
        void Save();
    }
}
