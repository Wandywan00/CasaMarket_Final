using System;
namespace CasaMarket.Domain.Entities
{

    public class ImagesProduct()
    {
        public readonly int ImageProductID;

        public int ImagesID { get; set; }
        public int ProductID { get; set; }
        public string ImageUrl { get; set; }

    }
}