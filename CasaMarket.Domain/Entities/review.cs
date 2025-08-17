using System;

namespace CasaMarket.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }   

        public int UserID { get; set; }
        public User? User { get; set; }         

        public int Punctuation { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
    }
}
