namespace SalesOrder.API.Models
{
    public class OrderLine
    {
        public string skuCode { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
    }
}
