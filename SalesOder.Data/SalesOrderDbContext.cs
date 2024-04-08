using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOder.Data
{
   
        public class SalesOrderDbContext : DbContext
        {
            public SalesOrderDbContext(DbContextOptions<SalesOrderDbContext> options)
                : base(options)
            {
            }

            public DbSet<XSLTFile> XSLTFiles { get; set; }
        }
    }

