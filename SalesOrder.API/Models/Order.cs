namespace SalesOrder.API.Models
{
    public class Order
    {
        public string orderRef { get; set; }
        public string orderDate { get; set; }
        public string currency { get; set; }
        public string shipDate { get; set; }
        public string categoryCode { get; set; }
        public List<Address> addresses { get; set; }
        public List<OrderLine> lines { get; set; }
    }
}
