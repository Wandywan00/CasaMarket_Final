using System.Data.Entity;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

public class ReviewRepository
{
    private readonly CasaMarketApplicationContext context;

    public ReviewRepository(CasaMarketApplicationContext context)
    {
        this.context = context;
    }

    public async Task<List<review>> GetAllReviewsAsync()
    {
        return await context.review
            .Include(r => r.ProductID)
        .Include(r => r.UserID)
            .ToListAsync();
    }

    public async Task<review> GetReviewByIdAsync(int id)
    {
        return await context.review
            .Include(r => r.ProductID)
            .Include(r => r.UserID)
            .FirstOrDefaultAsync(r => r.ReviewID == id);
    }

    public async Task AddReviewAsync(review review)
    {
        context.review.Add(review);
        await context.SaveChangesAsync();
    }

    public async Task UpdateReviewAsync(review review)
    {
        context.review.Update(review);
        await context.SaveChangesAsync();
    }

    public async Task DeleteReviewAsync(int id)
    {
        var review = await GetReviewByIdAsync(id);
        if (review != null)
        {
            context.review.Remove(review);
            await context.SaveChangesAsync();
        }
    }
}