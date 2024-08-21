using OllieShop.Cargo.DataAccessLayer.Abstract;
using OllieShop.Cargo.DataAccessLayer.Concrete;
using OllieShop.Cargo.DataAccessLayer.Repositories;

namespace OllieShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDal : GenericRepository<EntityLayer.Concrete.Cargo>, ICargoDal
    {
        public EfCargoDal(CargoContext context) : base(context)
        {
        }
    }
}
