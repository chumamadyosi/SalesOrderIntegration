namespace SalesOrder.API.Models
{
    public class Address
    {
        public string addressType { get; set; }
        public int locationNumber { get; set; }
        public string contactName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string addressLine1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postcode { get; set; }
        public string countryCode { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string locationNumberQualifier { get; set; }
    }
}
