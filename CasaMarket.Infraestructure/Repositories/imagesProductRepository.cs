using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ImagesProductRepository
{
    private readonly CasaMarketApplicationContext context;

    public ImagesProductRepository(CasaMarketApplicationContext context)
    {
        this.context = context;
    }

    public async Task<List<ImagesProduct>> GetAllImagesAsync()
    {
        return await context.imagesProducts
            .Include(i => i.ImageProductID)
            .ToListAsync();
    }

    public async Task<ImagesProduct> GetImageByIdAsync(int id)
    {
        return await context.imagesProducts
            .Include(i => i.ProductID)
            .FirstOrDefaultAsync(i => i.ImageProductID == id);
    }

    public async Task AddImageAsync(ImagesProduct image)
    {
        context.imagesProducts.Add(image);
        await context.SaveChangesAsync();
    }

    public async Task UpdateImageAsync(ImagesProduct image)
    {
        context.imagesProducts.Update(image);
        await context.SaveChangesAsync();
    }

    public async Task DeleteImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        if (image != null)
        {
            context.imagesProducts.Remove(image);
            await context.SaveChangesAsync();
        }
    }
}
