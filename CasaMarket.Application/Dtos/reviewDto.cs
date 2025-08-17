using System;

namespace CasaMarket.Application.Dtos
{
    public class ReviewDto
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }

        public int Punctuation { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }

        public UserShortDto? User { get; set; }     
        public ProductShortDto? Product { get; set; }
    }


    public class ReviewShortDto
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int Punctuation { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
        public string? UserName { get; set; }
    }
}
