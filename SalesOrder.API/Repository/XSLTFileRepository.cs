using Microsoft.EntityFrameworkCore;
using SalesOder.Data;

namespace SalesOrder.API.Repository
{
    public class XSLTFileRepository : IXSLTFileRepository
    {
        private readonly SalesOrderDbContext _context;

        public XSLTFileRepository(SalesOrderDbContext context)
        {
            _context = context;
        }

        public async Task<XSLTFile> GetXSLTFileByOrderIdAsync(int orderId)
        {
            return await _context.XSLTFiles.FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task AddXSLTFileAsync(XSLTFile xsltFile)
        {
            _context.XSLTFiles.Add(xsltFile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateXSLTFileAsync(XSLTFile xsltFile)
        {
            _context.XSLTFiles.Update(xsltFile);
            await _context.SaveChangesAsync();
        }
    }
}
