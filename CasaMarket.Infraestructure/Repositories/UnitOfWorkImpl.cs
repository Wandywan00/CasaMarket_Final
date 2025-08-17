using System.Threading.Tasks;
using CasaMarket.Infrastructure.Data;

namespace CasaMarket.Infrastructure.Repositories
{
    public class UnitOfWorkImpl : UnitOfWork
    {
        private readonly CasaMarketApplicationContext _ctx;

        public ProductRepository Products { get; }
        public ReviewRepository Reviews { get; }
        public MessageRepository Messages { get; }
        public OrderRepository Orders { get; }
        public DetailOrderRepository DetailOrders { get; }
        public ImagesProductRepository ImagesProducts { get; }
        public UserRepository Users { get; }

        public UnitOfWorkImpl(
            CasaMarketApplicationContext ctx,
            ProductRepository products,
            ReviewRepository reviews,
            MessageRepository messages,
            OrderRepository orders,
            DetailOrderRepository detailOrders,
            ImagesProductRepository imagesProducts,
            UserRepository users)
        {
            _ctx = ctx;
            Products = products;
            Reviews = reviews;
            Messages = messages;
            Orders = orders;
            DetailOrders = detailOrders;
            ImagesProducts = imagesProducts;
            Users = users;
        }

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
    }
}
