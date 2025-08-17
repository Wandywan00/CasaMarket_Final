using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Infrastructure.Data;
using CasaMarket.Domain.Entities;

namespace CasaMarket.Infrastructure.Repositories
{
    public class MessageRepository
    {
        private readonly CasaMarketApplicationContext _context;

        public MessageRepository(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Set<Message>()
                .FirstOrDefaultAsync(m => m.MessageID == id);
        }

        public async Task<List<Message>> GetInboxAsync(int userId)
        {
            return await _context.Set<Message>()
                .Where(m => m.AddresseeID == userId)
                .OrderByDescending(m => m.ShippingDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetSentAsync(int userId)
        {
            return await _context.Set<Message>()
                .Where(m => m.SenderID == userId)
                .OrderByDescending(m => m.ShippingDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetConversationAsync(int userA, int userB)
        {
            return await _context.Set<Message>()
                .Where(m => (m.SenderID == userA && m.AddresseeID == userB) ||
                            (m.SenderID == userB && m.AddresseeID == userA))
                .OrderBy(m => m.ShippingDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetUnreadAsync(int userId)
        {
            return await _context.Set<Message>()
                .Where(m => m.AddresseeID == userId && !m.IsRead)
                .OrderByDescending(m => m.ShippingDate)
                .ToListAsync();
        }

        public async Task AddAsync(Message entity)
        {
            await _context.Set<Message>().AddAsync(entity);
        }

        public async Task<bool> MarkAsReadAsync(int id)
        {
            var msg = await _context.Set<Message>().FirstOrDefaultAsync(m => m.MessageID == id);
            if (msg == null) return false;
            msg.IsRead = true;
            _context.Set<Message>().Update(msg);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var msg = await _context.Set<Message>().FindAsync(id);
            if (msg == null) return false;
            _context.Set<Message>().Remove(msg);
            return true;
        }
    }
}
