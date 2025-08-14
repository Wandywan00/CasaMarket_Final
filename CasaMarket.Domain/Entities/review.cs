using System;

namespace CasaMarket.Domain.Entities
{ 

    public class review()
	{
		public int ReviewID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public int punctuation { get; set; }
    public string comment { get; set; } 
    public string reviewDate { get; set; }


}
}