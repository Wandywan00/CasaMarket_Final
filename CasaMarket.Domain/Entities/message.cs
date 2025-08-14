using System;

namespace CasaMarket.Domain.Entities { 

    public class message()
	{
        public readonly object Receiver;

        public int MessageID { get; set; }
    public int SenderI { get; set; }
    public int AddresseeID { get; set; }
    public string text { get; set; }
    public DateTime ShippingDate { get; set; }
    public string read { get; set; }


}
}