using Microsoft.AspNetCore.Hosting;
using SalesOder.Data;
using SalesOrder.API.Repository;
using SalesOrder.API.Sevices.IXSLTFile;
using System.IO;
using System.Threading.Tasks;

namespace SalesOrder.API.Services
{
    public class XSLTFileService : IXSLTFileService
    {
        private readonly IXSLTFileRepository _xsltFileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public XSLTFileService(IXSLTFileRepository xsltFileRepository, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _xsltFileRepository = xsltFileRepository;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration; // Assign IConfiguration
        }

        public async Task AddXSLTFileAsync(string name, string type, byte[] content)
        {
            await SaveXSLTFileAsync(name, content);
            var xsltFile = new XSLTFile
            {
                Name = name,
                Type = type
            };
            await _xsltFileRepository.AddXSLTFileAsync(xsltFile);
        }

        public Task<string> GetXSLTFilePathByTypeAsync(string type)
        {
          
            var outputPath = _configuration["XSLTFileSettings:ConvertedFilesOutputPath"];

            var fileName = $"{type}.xsl";
            var outputFilePath = Path.Combine(outputPath, fileName);

            return Task.FromResult(outputFilePath);
        }

        private async Task SaveXSLTFileAsync(string name, byte[] content)
        {
            var xsltFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "XSLTFiles", name);
            await File.WriteAllBytesAsync(xsltFilePath, content);
        }
    }
}
