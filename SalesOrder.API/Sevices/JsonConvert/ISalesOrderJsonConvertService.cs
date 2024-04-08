using Newtonsoft.Json.Linq;

namespace SalesOrder.API.Sevices.Sales
{
    public interface ISalesOrderJsonConvertService
    {
        Task<string> ConvertSalesOrder(JObject salesOrderJson);
        Task<string> ConvertSalesOrderAcknowledgement(JObject salesOrderJson);
    }
}
