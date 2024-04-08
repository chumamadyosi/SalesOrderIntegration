using SalesOder.Data;

namespace SalesOrder.API.Repository
{
    public interface IXSLTFileRepository
    {
            Task<XSLTFile> GetXSLTFileByOrderIdAsync(int orderId);
            Task AddXSLTFileAsync(XSLTFile xsltFile);
            Task UpdateXSLTFileAsync(XSLTFile xsltFile);
        }
    }
}

