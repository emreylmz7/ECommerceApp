using System.Linq.Expressions;

namespace OllieShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByIdsAsync(IEnumerable<int> ids); 
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetPagedAsync(int pageIndex, int pageSize);
    }
}
