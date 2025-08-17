namespace CasaMarket.Infrastructure.Repositories
{
    public interface UnitOfWork
    {
        ProductRepository Products { get; }
        ReviewRepository Reviews { get; }
        MessageRepository Messages { get; }
        OrderRepository Orders { get; }
        DetailOrderRepository DetailOrders { get; }
        ImagesProductRepository ImagesProducts { get; }
        UserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
