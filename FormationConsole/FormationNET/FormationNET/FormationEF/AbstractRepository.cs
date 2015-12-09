using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public abstract class AbstractRepository<T> : IRepository<T> where T :class
    {

        public FormationEntities Entities { get; set; }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> l = Entities.Set<T>().ToList();
            return l;
        }

        public T GetById(int id)
        {
            return Entities.Set<T>().Find(id);

        }

        public IEnumerable<T> GetByLambda(Func<T, bool> where, int page = 0, int nbRow = 1000)
        {
            return Entities.Set<T>().Where(where).Skip((page) * nbRow).Take(nbRow);
        }

        public T Insert(T entity)
        {
            Entities.Set<T>().Add(entity);
            return entity;
        }

        public void Remove(T entity)
        {
            Entities.Set<T>().Remove(entity);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
