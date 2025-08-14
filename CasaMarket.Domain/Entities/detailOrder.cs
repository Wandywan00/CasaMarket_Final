namespace CasaMarket.Domain.Entities
{
    public class DetailOrder
    {
        public int DetailOrderID { get; set; }

        public int OrderID { get; set; }  // FK
        public Order Order { get; set; }  // Propiedad de navegación

        public int SellerID { get; set; }
        public User Seller { get; set; } // Propiedad de navegación opcional

        public string State { get; set; }
    }
}
