using Microsoft.EntityFrameworkCore;

namespace OllieShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=OllieShopCommentDb;User=sa;Password=123456aA*");
        }

        public DbSet<Entities.Comment> Comments { get; set; }
    }
}
