using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    public class ReviewRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public ReviewRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

    
        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Product)
                .OrderByDescending(r => r.ReviewDate)
                .ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(r => r.ReviewID == id);
        }

      
        public async Task<List<Review>> GetByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductID == productId)
                .Include(r => r.User)
                .OrderByDescending(r => r.ReviewDate)
                .ToListAsync();
        }

        
        public async Task<List<Review>> GetByUserIdAsync(int userId)
        {
            return await _context.Reviews
                .Where(r => r.UserID == userId)
                .Include(r => r.Product)
                .OrderByDescending(r => r.ReviewDate)
                .ToListAsync();
        }

        public async Task AddAsync(Review entity)
        {
            await _context.Reviews.AddAsync(entity);
        }

      
        public void Update(Review entity)
        {
            _context.Reviews.Update(entity);
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);
            if (Review == null) return false;
            _context.Reviews.Remove(Review);
            return true;
        }
    }
}
