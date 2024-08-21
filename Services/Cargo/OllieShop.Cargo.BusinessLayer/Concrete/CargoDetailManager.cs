using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DataAccessLayer.Abstract;
using OllieShop.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace OllieShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDetailDal.DeleteAsync(id);
        }

        public async Task<List<CargoDetail>> TGetAllAsync()
        {
            return await _cargoDetailDal.GetAllAsync();
        }

        public async Task<List<CargoDetail>> TGetByFilterAsync(Expression<Func<CargoDetail, bool>> predicate)
        {
            return await _cargoDetailDal.GetByFilterAsync(predicate);
        }

        public async Task<CargoDetail> TGetByIdAsync(int id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task<List<CargoDetail>> TGetByIdsAsync(IEnumerable<int> ids)
        {
            return await _cargoDetailDal.GetByIdsAsync(ids);
        }

        public async Task<List<CargoDetail>> TGetPagedAsync(int pageIndex, int pageSize)
        {
            return await _cargoDetailDal.GetPagedAsync(pageIndex, pageSize);
        }

        public async Task TInsertAsync(CargoDetail entity)
        {
            await _cargoDetailDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoDetail entity)
        {
            await _cargoDetailDal.UpdateAsync(entity);
        }
    }
}
