using System;
using System.Collections.Generic;

namespace CasaMarket.Application.Dtos
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int BuyerID { get; set; }
        public UserShortDto? Buyer { get; set; }

        public int SellerID { get; set; }
        public string State { get; set; } = "Pending";
        public DateTime OrderDate { get; set; }

        public List<DetailOrderDto> Details { get; set; } = new();

        public decimal Subtotal
        {
            get
            {
                decimal sum = 0;
                foreach (var d in Details)
                    sum += d.LineTotal;
                return sum;
            }
        }
        public decimal Tax { get; set; } = 0; 
        public decimal Total => Subtotal + Tax;
    }
}
