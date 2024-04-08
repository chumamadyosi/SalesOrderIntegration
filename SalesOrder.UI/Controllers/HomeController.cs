using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalesOrder.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HomeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            string baseUrl = _configuration["ApiBaseUrl"];
            _httpClient.BaseAddress = new System.Uri(baseUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "No file uploaded.";
                return View("Index");
            }

      
            using (var stream = file.OpenReadStream())
            {
                var content = new StreamContent(stream);

                var response = await _httpClient.PostAsync("/api/SalesOrder/Convert", content);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "File uploaded and processed successfully.";
                }
                else
                {
                    ViewBag.Message = "Error processing file.";
                }
            }

            return View("Index");
        }
    }
}
