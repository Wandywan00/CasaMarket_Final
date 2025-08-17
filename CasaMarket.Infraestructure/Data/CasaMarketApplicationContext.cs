using Microsoft.EntityFrameworkCore;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Data
{
    public class CasaMarketApplicationContext : DbContext
    {
        public CasaMarketApplicationContext(
            DbContextOptions<CasaMarketApplicationContext> options) : base(options) { }

        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<ImagesProduct> ImagesProducts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
