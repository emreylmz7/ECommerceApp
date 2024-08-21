using Microsoft.EntityFrameworkCore;
using OllieShop.Cargo.DataAccessLayer.Abstract;
using OllieShop.Cargo.DataAccessLayer.Concrete;
using System.Linq.Expressions;

namespace OllieShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Set<T>()
                .Where(entity => ids.Contains(GetEntityId(entity)))
                .ToListAsync();
        }

        public async Task<List<T>> GetPagedAsync(int pageIndex, int pageSize)
        {
            return await _context.Set<T>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        private int GetEntityId(T entity)
        {
            // T sınıfının Id özelliğine erişim için refleksiyon kullanılır.
            var property = typeof(T).GetProperty("Id");
            if (property == null)
            {
                throw new InvalidOperationException("Entity does not have an Id property.");
            }
            return (int)property.GetValue(entity);
        }
    }
}
