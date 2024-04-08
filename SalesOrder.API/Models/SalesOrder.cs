using System.Net;

namespace SalesOrder.API.Models
{
    public class SalesOrder
    {
        public string salesOrderRef { get; set; }
        public string orderDate { get; set; }
        public string currency { get; set; }
        public string shipDate { get; set; }
        public string categoryCode { get; set; }
        public List<Address> addresses { get; set; }
        public List<OrderLine> orderLines { get; set; }
    }
}
