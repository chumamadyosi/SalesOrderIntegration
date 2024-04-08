using Newtonsoft.Json.Linq;
using SalesOrder.API.Sevices.IXSLTFile;
using SalesOrder.API.Sevices.Sales;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Xml;
using Newtonsoft.Json;
using System.Text;

namespace SalesOrder.API.Services
{
    public class SalesOrderJsonConvertService : ISalesOrderJsonConvertService
    {
        private readonly IXSLTFileService _xsltFileService;

        public SalesOrderJsonConvertService(IXSLTFileService xsltFileService)
        {
            _xsltFileService = xsltFileService;
        }

        public async Task<string> ConvertSalesOrder(JObject salesOrderJson)
        {
            var xsltType = "SalesOrder";
            var transformedJson = await TransformJsonWithXSLTAsync(salesOrderJson, xsltType);
            return transformedJson;
        }

        public async Task<string> ConvertSalesOrderAcknowledgement(JObject salesOrderJson)
        {
            var xsltType = "SalesOrderAcknowledgement";
            var transformedJson = await TransformJsonWithXSLTAsync(salesOrderJson, xsltType);
            return transformedJson;
        }

        public async Task<string> TransformJsonWithXSLTAsync(JObject json, string xsltType)
        {
            // Load the XSLT file path from configuration
            var xsltFilePath = await _xsltFileService.GetXSLTFilePathByTypeAsync(xsltType);

            // Check if XSLT file exists
            if (!File.Exists(xsltFilePath))
            {
                throw new FileNotFoundException($"XSLT file '{xsltType}.xsl' not found.");
            }

            // Load XSLT transform
            var xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            // Convert JObject to XML string
            var jsonString = json.ToString();
            var xmlString = JsonConvert.DeserializeXmlNode(jsonString, "root").OuterXml;

            // Load XML string as XML document
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            // Perform XSLT transformation
            var transformedXml = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(transformedXml))
            {
                xslt.Transform(xmlDocument, xmlWriter);
            }

            // Convert transformed XML to string
            var transformedJson = transformedXml.ToString();

            // Save the transformed content to the database and file path
            await _xsltFileService.AddXSLTFileAsync($"{xsltType}.xsl", xsltType, Encoding.UTF8.GetBytes(transformedJson));

            return transformedJson;
        }

    }
}
