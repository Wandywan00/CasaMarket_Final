using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

namespace CasaMarket.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public UserRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetByRoleAsync(string role)
        {
            return await _context.Users
                .Where(u => u.Role == role)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<List<User>> SearchByNameAsync(string term)
        {
            term = term.ToLower();
            return await _context.Users
                .Where(u => u.Name.ToLower().Contains(term))
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

     
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

      
        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) return false;

            _context.Users.Remove(user);
            return true;
        }
    }
}
