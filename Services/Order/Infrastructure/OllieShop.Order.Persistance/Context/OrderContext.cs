using Microsoft.EntityFrameworkCore;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Persistance.Context
{
    public class OrderContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=OllieShopOrderDb;User=sa;Password=123456aA*");
            //Database = OllieShopOrderDb; Trusted_Connection = True; TrustServerCertificate = True
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
