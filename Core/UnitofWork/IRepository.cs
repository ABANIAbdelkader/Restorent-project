using Elfie.Serialization;
using System.Linq.Expressions;

namespace Core.UnitofWork
{
    public interface IRepository<T> where T : class
    {

        public T FindById(int id);
        public IEnumerable<T> FindAll(Func<T, bool> predicate);
        public Task<T> FindByIdAsync(int id);
        public Task<IEnumerable<T>> FindAllAsync();
        public bool add(T entity);
        public bool Delete(T entity);

        public bool update(T entity);

    }
}
