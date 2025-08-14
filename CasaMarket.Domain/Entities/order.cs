namespace CasaMarket.Domain.Entities
{
    public class Order
    {
        public readonly object DetailOrders;

        public int OrderID { get; set; }

        public int BuyerID { get; set; }   // FK
        public User Buyer { get; set; }    // Propiedad de navegación

        public int SellerID { get; set; }
        public string State { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
