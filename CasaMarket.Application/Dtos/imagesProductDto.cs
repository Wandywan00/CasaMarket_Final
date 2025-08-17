namespace CasaMarket.Application.Dtos
{
    public class ImagesProductDto
    {
        public int ImagesProductID { get; set; }
        public int ProductID { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
