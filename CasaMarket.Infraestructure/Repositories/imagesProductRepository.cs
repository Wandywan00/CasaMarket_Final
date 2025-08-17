using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

namespace CasaMarket.Infrastructure.Repositories
{
    public class ImagesProductRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public ImagesProductRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ImagesProduct>> GetAllAsync()
        {
            return await _context.ImagesProducts.ToListAsync();
        }

        public async Task<ImagesProduct?> GetByIdAsync(int id)
        {
            return await _context.ImagesProducts
                .FirstOrDefaultAsync(ip => ip.ImagesProductID == id);
        }

        public async Task<List<ImagesProduct>> GetByProductIdAsync(int productId)
        {
            return await _context.ImagesProducts
                .Where(ip => ip.ProductID == productId)
                .ToListAsync();
        }

        public async Task AddAsync(ImagesProduct entity)
        {
            await _context.ImagesProducts.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<ImagesProduct> entities)
        {
            await _context.ImagesProducts.AddRangeAsync(entities);
        }

        public void Update(ImagesProduct entity)
        {
            _context.ImagesProducts.Update(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ImagesProducts.FindAsync(id);
            if (entity == null) return false;
            _context.ImagesProducts.Remove(entity);
            return true;
        }

        public async Task<int> DeleteByProductIdAsync(int productId)
        {
            var list = await _context.ImagesProducts
                .Where(ip => ip.ProductID == productId)
                .ToListAsync();

            if (list.Count == 0) return 0;

            _context.ImagesProducts.RemoveRange(list);
            return list.Count;
        }
    }
}
