using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class OrderRepository
{
    private readonly CasaMarketApplicationContext context;

    public OrderRepository(CasaMarketApplicationContext context)
    {
        this.context = context;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await context.orders
            .Include(o => o.Buyer)
            .Include(o => o.DetailOrders)
            .ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await context.orders
            .Include(o => o.Buyer)
            .Include(o => o.DetailOrders)
            .FirstOrDefaultAsync(o => o.OrderID == id);
    }

    public async Task AddOrderAsync(Order order)
    {
        context.orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        context.orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await GetOrderByIdAsync(id);
        if (order != null)
        {
            context.orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }
}