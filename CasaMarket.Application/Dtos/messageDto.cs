using System;

namespace CasaMarket.Application.Dtos
{
    public class MessageDto
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int AddresseeID { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime ShippingDate { get; set; }
        public bool IsRead { get; set; }

        public string? SenderName { get; set; }
        public string? AddresseeName { get; set; }
    }
}
