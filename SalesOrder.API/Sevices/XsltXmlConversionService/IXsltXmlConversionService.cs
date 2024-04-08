namespace SalesOrder.API.Sevices.XsltXmlConversionService
{
    public interface IXsltXmlConversionService
    {
        Task<string> ConvertJsonToXml(string json, string xsltFilePath);
    }
}
