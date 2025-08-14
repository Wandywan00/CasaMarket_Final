using System.Data.Entity;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

public class ProductRepository
{
    private readonly CasaMarketApplicationContext context;

    public ProductRepository(CasaMarketApplicationContext context)
    {
        this.context = context;
    }

    public async Task<List<product>> GetAllProductsAsync()
    {
        return await context.products
            .Include(p => p.userID)
        .Include(p => p.Images)
            .ToListAsync();
    }

    public async Task<product> GetProductByIdAsync(int id)
    {
        return await context.products
            .Include(p => p.userID)
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProductID == id);
    }

    public async Task AddProductAsync(product product)
    {
        context.products.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(product product)
    {
        context.products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await GetProductByIdAsync(id);
        if (product != null)
        {
            context.products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}