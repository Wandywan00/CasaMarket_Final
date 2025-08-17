using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class OrderService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var entities = await unitOfWork.Orders.GetAllAsync();

            return entities.Select(o => new OrderDto
            {
                OrderID = o.OrderID,
                BuyerID = o.BuyerID,
                SellerID = o.SellerID,
                State = o.State,
                OrderDate = o.OrderDate,
                Buyer = o.Buyer != null ? new UserShortDto
                {
                    UserID = o.Buyer.UserID,
                    Name = o.Buyer.Name
                } : null,
                Details = o.DetailOrders.Select(d => new DetailOrderDto
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
                }).ToList()
            }).ToList();
        }
    }
}
