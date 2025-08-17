namespace CasaMarket.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public int BuyerID { get; set; }
        public User? Buyer { get; set; }         

        public int SellerID { get; set; }
        public string State { get; set; } = "Pending";
        public DateTime OrderDate { get; set; }

        public ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
    }
}