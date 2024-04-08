// XmlConversionController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SalesOrder.API.Services;
using SalesOrder.API.Sevices.XsltXmlConversionService;
using System;
using System.Threading.Tasks;

namespace SalesOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlConversionController : ControllerBase
    {
        private readonly IXsltXmlConversionService _xmlConversionService;

        public XmlConversionController(IXsltXmlConversionService xmlConversionService)
        {
            _xmlConversionService = xmlConversionService;
        }

        [HttpPost("convert")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConvertJsonToXml([FromBody] JObject jsonData, [FromQuery] string xsltFileName)
        {
            try
            {
                if (string.IsNullOrEmpty(xsltFileName))
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse("XSLT file name is required."));
                }

                var json = jsonData.ToString();
                var xsltFilePath = $"XSLTFiles/{xsltFileName}.xsl";

                var xmlResult = await _xmlConversionService.ConvertJsonToXml(json, xsltFilePath);
                return Ok(ApiResponse<string>.SuccessResponse(xmlResult));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting JSON to XML: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<object>.ErrorResponse("Internal Server Error"));
            }
        }
    }
}
