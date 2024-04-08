namespace SalesOrder.API.Sevices.IXSLTFile
{
    public interface IXSLTFileService
    {
        Task AddXSLTFileAsync(string name, string type, byte[] content);
        Task<string> GetXSLTFilePathByTypeAsync(string type);
    }
}
