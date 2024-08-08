using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OrderContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
