using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SalesOrder.API.Sevices.Sales;
namespace SalesOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonConversionController : ControllerBase
    {
        private readonly ISalesOrderJsonConvertService _salesOrderService;

        public JsonConversionController(ISalesOrderJsonConvertService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        [HttpPost("convert")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult ConvertSalesOrder([FromBody] JObject salesOrderJson)
        {
            try
            {
                var expectedSalesOrderJson = _salesOrderService.ConvertSalesOrder(salesOrderJson);
                var expectedSalesOrderAckJson = _salesOrderService.ConvertSalesOrderAcknowledgement(salesOrderJson);

                return Ok(ApiResponse<bool>.SuccessResponse(true));

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error converting sales order: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<object>.ErrorResponse("Internal Server Error"));
            }
        }

    }
}
