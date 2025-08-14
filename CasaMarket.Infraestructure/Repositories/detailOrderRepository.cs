using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    public class DetailOrderRepository
    {
        private readonly CasaMarketApplicationContext context;

        public DetailOrderRepository(CasaMarketApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<DetailOrder>> GetAllDetailOrdersAsync()
        {
            return await context.detailOrders
                .Include(d => d.Order)         
                    .ThenInclude(o => o.Buyer) 
                .ToListAsync();
        }

        public async Task<DetailOrder> GetDetailOrderByIdAsync(int id)
        {
            return await context.detailOrders
                .Include(d => d.Order)
                    .ThenInclude(o => o.Buyer)
                .FirstOrDefaultAsync(d => d.DetailOrderID == id);
        }

        public async Task AddDetailOrderAsync(DetailOrder detailOrder)
        {
            context.detailOrders.Add(detailOrder);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDetailOrderAsync(DetailOrder detailOrder)
        {
            context.detailOrders.Update(detailOrder);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDetailOrderAsync(int id)
        {
            var detailOrder = await GetDetailOrderByIdAsync(id);
            if (detailOrder != null)
            {
                context.detailOrders.Remove(detailOrder);
                await context.SaveChangesAsync();
            }
        }
    }
}
