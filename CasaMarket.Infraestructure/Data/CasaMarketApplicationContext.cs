using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Data
{
    public class CasaMarketApplicationContext : DbContext
    {
        public CasaMarketApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<DetailOrder> detailOrders { get; set; }
        public DbSet<ImagesProduct> imagesProducts { get; set; }
        public DbSet<message> messages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<review> review { get; set; }
        public DbSet<User> users { get; set; }
    }
}
