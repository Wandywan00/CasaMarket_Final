using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

namespace CasaMarket.Infrastructure.Repositories
{
    public class DetailOrderRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public DetailOrderRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<DetailOrder>> GetAllAsync()
        {
            return await _context.DetailOrders
                .Include(d => d.Order)
                .Include(d => d.ProductID)    
                .ToListAsync();
        }

     
        public async Task<DetailOrder?> GetByIdAsync(int id)
        {
            return await _context.DetailOrders
                .Include(d => d.Order)
                .Include(d => d.ProductID)
                .FirstOrDefaultAsync(d => d.DetailOrderID == id);
        }

 
        public async Task<List<DetailOrder>> GetByOrderIdAsync(int orderId)
        {
            return await _context.DetailOrders
                .Where(d => d.OrderID == orderId)
                .Include(d => d.ProductID)
                .ToListAsync();
        }

    
        public async Task AddAsync(DetailOrder entity)
        {
            await _context.DetailOrders.AddAsync(entity);
        }

       
        public void Update(DetailOrder entity)
        {
            _context.DetailOrders.Update(entity);
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DetailOrders.FindAsync(id);
            if (entity == null) return false;
            _context.DetailOrders.Remove(entity);
            return true;
        }
    }
}
