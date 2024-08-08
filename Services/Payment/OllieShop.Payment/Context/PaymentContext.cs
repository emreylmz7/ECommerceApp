using Microsoft.EntityFrameworkCore;

namespace OllieShop.Payment.Context
{
    public class PaymentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=OllieShopPaymentDb;User=sa;Password=123456aA*");
        }

        public DbSet<Entities.Payment> Payments { get; set; }
    }
}
