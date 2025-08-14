using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Infraestructure.Repositories
{
    public class UnitOfWork
    {
        private readonly CasaMarketApplicationContext _context;
        public DetailOrderRepository DetailOrders { get; }
        public ImagesProductRepository ImagesProducts { get; }
        public MessageRepository Messages { get; }
        public OrderRepository Orders { get; }
        public ProductRepository Products { get; }
        public ReviewRepository Reviews { get; }
        public UserRepository Users { get; }

        public UnitOfWork(CasaMarketApplicationContext DetailOrderRepository, DetailOrder DetailOrderRepository)
        {
           this._context = DetailOrderRepository;
        }
    }
}
