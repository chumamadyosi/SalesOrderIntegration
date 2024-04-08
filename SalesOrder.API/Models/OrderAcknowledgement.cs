namespace SalesOrder.API.Models
{
    public class OrderAcknowledgement
    {
        public string orderRef { get; set; }
        public string internalRef { get; set; }
        public string status { get; set; }
        public string receivedDate { get; set; }
        public List<ReceivedItem> receivedItems { get; set; }
    }
}
