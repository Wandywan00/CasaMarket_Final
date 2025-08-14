using System;

namespace CasaMarket.Domain.Entities { 

    public class product()
	{
        public readonly object Images;

        public int ProductID { get; set; }
    public string userID { get; set; }
    public string Name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public string category { get; set; }
    public int Stock { get; set; }
    public int PublicationDate { get; set; }
    public string state { get; set; }
    
    
}
}
