using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    // UserRepository
    public class UserRepository
    {
        private readonly CasaMarketApplicationContext context;

        public UserRepository(CasaMarketApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await context.users.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task AddUserAsync(User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            context.users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                context.users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}