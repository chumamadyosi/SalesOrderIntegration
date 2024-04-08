using SalesOrder.API.Sevices.XsltXmlConversionService;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace SalesOrder.API.Services
{
    public class XsltXmlConversionService : IXsltXmlConversionService
    {
        public async Task<string> ConvertJsonToXml(string json, string xsltFilePath)
        {
            // Load XSLT transform
            var xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            // Load JSON as XML
            var xmlSettings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            using var xmlReader = XmlReader.Create(new StringReader(json), xmlSettings);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlReader);

            // Perform XSLT transformation
            var transformedXml = new StringWriter();
            using var xmlWriter = XmlWriter.Create(transformedXml);
            xslt.Transform(xmlDocument, xmlWriter);

            return transformedXml.ToString();
        }
    }
}
