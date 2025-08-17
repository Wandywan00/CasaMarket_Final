using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class ImagesProductService
    {
        private readonly UnitOfWork unitOfWork;
        public ImagesProductService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<ImagesProductDto>> GetByProductAsync(int productId)
        {
            var entities = await unitOfWork.ImagesProducts.GetByProductIdAsync(productId);

            return entities.Select(ip => new ImagesProductDto
            {
                ImagesProductID = ip.ImagesProductID,
                ProductID = ip.ProductID,
                ImageUrl = ip.ImageUrl
            }).ToList();
        }
    }
}
