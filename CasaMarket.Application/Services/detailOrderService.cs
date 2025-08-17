using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class DetailOrderService
    {
        private readonly UnitOfWork unitOfWork;
        public DetailOrderService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<DetailOrderDto>> GetByOrderAsync(int orderId)
        {
            var entities = await unitOfWork.DetailOrders.GetByOrderIdAsync(orderId);

            return entities.Select(d => new DetailOrderDto
            {
                DetailOrderID = d.DetailOrderID,
                OrderID = d.OrderID,
                ProductID = d.ProductID,
                Product = d.Product != null ? new ProductShortDto
                {
                    ProductID = d.Product.ProductID,
                    Name = d.Product.Name,
                    Price = d.Product.Price
                } : null
            }).ToList();
        }
    }
}
