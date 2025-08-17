namespace CasaMarket.Domain.Entities
{
    public class DetailOrder
    {
        public int DetailOrderID { get; set; }

        public int OrderID { get; set; }
        public Order? Order { get; set; }         

        public int ProductID { get; set; }
        public Product? Product { get; set; }    
    }
}