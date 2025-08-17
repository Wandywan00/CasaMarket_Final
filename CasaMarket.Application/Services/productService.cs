using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class ProductService
    {
        private readonly UnitOfWork unitOfWork;
        public ProductService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var entities = await unitOfWork.Products.GetAllAsync();

            return entities.Select(p => new ProductDto
            {
                ProductID = p.ProductID,
                UserID = p.UserID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                Stock = p.Stock,
                PublicationDate = p.PublicationDate,
                State = p.State,
                Images = p.ImagesProducts.Select(ip => new ImagesProductDto
                {
                    ImagesProductID = ip.ImagesProductID,
                    ProductID = ip.ProductID,
                    ImageUrl = ip.ImageUrl
                }).ToList(),
                Reviews = p.Reviews.Select(r => new ReviewShortDto
                {
                    ReviewID = r.ReviewID,
                    UserID = r.UserID,
                    Punctuation = r.Punctuation,
                    Comment = r.Comment,
                    ReviewDate = r.ReviewDate,
                    UserName = r.User != null ? r.User.Name : null
                }).ToList(),
                RatingAverage = p.Reviews.Any() ? p.Reviews.Average(r => r.Punctuation) : 0,
                RatingCount = p.Reviews.Count
            }).ToList();
        }

        public async Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
