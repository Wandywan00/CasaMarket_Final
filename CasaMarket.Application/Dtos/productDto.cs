using System;
using System.Collections.Generic;

namespace CasaMarket.Application.Dtos
{
    public class ProductDto
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

        public List<ImagesProductDto> Images { get; set; } = new();
        public List<ReviewShortDto> Reviews { get; set; } = new();
        public double RatingAverage { get; set; } 
        public int RatingCount { get; set; }
    }

 
    public class ProductShortDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ThumbnailUrl { get; set; } 
    }
}
