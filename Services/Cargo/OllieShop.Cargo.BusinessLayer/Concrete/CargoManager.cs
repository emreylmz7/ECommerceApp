using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DataAccessLayer.Abstract;
using System.Linq.Expressions;

namespace OllieShop.Cargo.BusinessLayer.Concrete
{
    public class CargoManager : ICargoService
    {
        private readonly ICargoDal _cargoDal;

        public CargoManager(ICargoDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDal.DeleteAsync(id);
        }

        public async Task<List<EntityLayer.Concrete.Cargo>> TGetAllAsync()
        {
            return await _cargoDal.GetAllAsync();
        }

        public async Task<List<EntityLayer.Concrete.Cargo>> TGetByFilterAsync(Expression<Func<EntityLayer.Concrete.Cargo, bool>> predicate)
        {
            return await _cargoDal.GetByFilterAsync(predicate);
        }

        public async Task<EntityLayer.Concrete.Cargo> TGetByIdAsync(int id)
        {
            return await _cargoDal.GetByIdAsync(id);
        }

        public async Task<List<EntityLayer.Concrete.Cargo>> TGetByIdsAsync(IEnumerable<int> ids)
        {
            return await _cargoDal.GetByIdsAsync(ids);
        }

        public async Task<List<EntityLayer.Concrete.Cargo>> TGetPagedAsync(int pageIndex, int pageSize)
        {
            return await _cargoDal.GetPagedAsync(pageIndex, pageSize);
        }

        public async Task TInsertAsync(EntityLayer.Concrete.Cargo entity)
        {
            await _cargoDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(EntityLayer.Concrete.Cargo entity)
        {
            await _cargoDal.UpdateAsync(entity);
        }
    }
}
