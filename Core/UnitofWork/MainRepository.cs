using Core.Data;
using Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace Core.UnitofWork
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context)
        {
            _context = context;
        }

        private AppDbContext _context { get; set; }
        public IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return _context.Set<T>();

        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);

        }
        public bool add(T entity)
        { if (entity == null) return false;else
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return true;
            }

        }

        public bool Delete(T entity)
        {
            if (entity == null) return false;
            else
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
        }

        public bool update(T entity)
        {
            if (entity == null) return false;
            else
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
