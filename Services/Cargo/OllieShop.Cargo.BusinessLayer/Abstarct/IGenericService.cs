using System.Linq.Expressions;

namespace OllieShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsertAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
        Task<List<T>> TGetByIdsAsync(IEnumerable<int> ids);
        Task<List<T>> TGetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> TGetPagedAsync(int pageIndex, int pageSize);
    }
}
