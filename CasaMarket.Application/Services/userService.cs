using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        public UserService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<UserDto>> GetAllAsync()
        {
            var entities = await unitOfWork.Users.GetAllAsync();

            return entities.Select(u => new UserDto
            {
                UserID = u.UserID,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }
    }
}
