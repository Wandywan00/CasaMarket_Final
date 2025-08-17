using CasaMarket.Application.Dtos;
using CasaMarket.Infrastructure.Repositories;

namespace CasaMarket.Application.Services
{
    public class MessageService
    {
        private readonly UnitOfWork unitOfWork;
        public MessageService(UnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<List<MessageDto>> GetInboxAsync(int userId)
        {
            var entities = await unitOfWork.Messages.GetInboxAsync(userId);

            return entities.Select(m => new MessageDto
            {
                MessageID = m.MessageID,
                SenderID = m.SenderID,
                AddresseeID = m.AddresseeID,
                Text = m.Text,
                ShippingDate = m.ShippingDate,
                IsRead = m.IsRead
            }).ToList();
        }
    }
}
