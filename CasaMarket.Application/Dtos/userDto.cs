namespace CasaMarket.Application.Dtos
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer";
    }


    public class UserShortDto
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
