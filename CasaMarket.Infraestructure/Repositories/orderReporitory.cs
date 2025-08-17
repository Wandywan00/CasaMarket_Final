using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public OrderRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product) 
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product) 
                .FirstOrDefaultAsync(o => o.OrderID == id);
        }

        public async Task<List<Order>> GetByBuyerAsync(int buyerId)
        {
            return await _context.Orders
                .Where(o => o.BuyerID == buyerId)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product) 
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<List<Order>> GetByStateAsync(string state)
        {
            return await _context.Orders
                .Where(o => o.State == state)
                .Include(o => o.Buyer)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product) 
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null) return false;

            _context.Orders.Remove(order);
            return true;
        }
    }
}
