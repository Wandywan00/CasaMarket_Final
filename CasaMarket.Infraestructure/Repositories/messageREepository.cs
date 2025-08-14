using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class MessageRepository
{
    private readonly CasaMarketApplicationContext context;

    public MessageRepository(CasaMarketApplicationContext context)
    {
        this.context = context;
    }

    public async Task<List<message>> GetAllMessagesAsync()
    {
        return await context.messages
            .Include(m => m.SenderI)
        .Include(m => m.Receiver)
            .ToListAsync();
    }

    public async Task<message> GetMessageByIdAsync(int id)
    {
        return await context.messages
            .Include(m => m.SenderI)
            .Include(m => m.Receiver)
            .FirstOrDefaultAsync(m => m.MessageID == id);
    }

    public async Task AddMessageAsync(message message)
    {
        context.messages.Add(message);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMessageAsync(message message)
    {
        context.messages.Update(message);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMessageAsync(int id)
    {
        var message = await GetMessageByIdAsync(id);
        if (message != null)
        {
            context.messages.Remove(message);
            await context.SaveChangesAsync();
        }
    }
}