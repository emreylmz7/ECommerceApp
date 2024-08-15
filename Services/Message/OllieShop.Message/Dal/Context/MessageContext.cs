using Microsoft.EntityFrameworkCore;
using OllieShop.Message.Dal.Entitites;

namespace OllieShop.Message.Dal.Context
{
    public class MessageContext:DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options):base(options)
        {
            
        }

        public DbSet<Entitites.Message> Messages { get; set; }
    }
}
