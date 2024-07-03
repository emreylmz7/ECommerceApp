using OllieShop.Cargo.DataAccessLayer.Abstract;
using OllieShop.Cargo.DataAccessLayer.Concrete;
using OllieShop.Cargo.DataAccessLayer.Repositories;
using OllieShop.Cargo.EntityLayer.Concrete;

namespace OllieShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
