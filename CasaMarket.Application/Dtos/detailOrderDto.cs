using System;

namespace CasaMarket.Application.Dtos
{
    public class DetailOrderDto
    {
        public int DetailOrderID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }

    
        public ProductShortDto? Product { get; set; }
        public int Quantity { get; set; } = 1; 
        public decimal UnitPrice { get; set; } 
        public decimal LineTotal => UnitPrice * Quantity;
    }
}
