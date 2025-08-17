using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class ReviewService
    {
        private readonly UnitOfWork unitOfWork;
        public ReviewService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<ReviewDto>> GetAllAsync()
        {
            var entities = await unitOfWork.Reviews.GetAllAsync();

            return entities.Select(r => new ReviewDto
            {
                ReviewID = r.ReviewID,
                ProductID = r.ProductID,
                UserID = r.UserID,
                Punctuation = r.Punctuation,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate,
                User = r.User != null ? new UserShortDto
                {
                    UserID = r.User.UserID,
                    Name = r.User.Name
                } : null,
                Product = r.Product != null ? new ProductShortDto
                {
                    ProductID = r.Product.ProductID,
                    Name = r.Product.Name,
                    Price = r.Product.Price
                } : null
            }).ToList();
        }
    }
}
