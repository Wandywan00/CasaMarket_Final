namespace CasaMarket.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime PublicationDate { get; set; }
        public string State { get; set; } = "Active";

        public ICollection<ImagesProduct> ImagesProducts { get; set; } = new List<ImagesProduct>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}