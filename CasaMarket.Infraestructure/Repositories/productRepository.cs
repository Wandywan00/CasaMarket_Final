using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public ProductRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ImagesProducts)
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User)                
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ImagesProducts)
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User)                
                .FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<List<Product>> GetByCategoryAsync(string category)
        {
            return await _context.Products
                .Where(p => p.Category == category)
                .Include(p => p.ImagesProducts)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        public async Task<List<Product>> SearchByNameAsync(string term)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(term, System.StringComparison.OrdinalIgnoreCase))
                .Include(p => p.ImagesProducts)
                .ToListAsync();
        }

        public async Task<List<Product>> GetBySellerAsync(int userId)
        {
            return await _context.Products
                .Where(p => p.UserID == userId)
                .Include(p => p.ImagesProducts)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }

        public async Task<bool> UpdateStockAsync(int productId, int newStock)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return false;
            product.Stock = newStock;
            _context.Products.Update(product);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null) return false;
            _context.Products.Remove(entity);
            return true;
        }
    }
}
