using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CryptoTestContextFactory : IDesignTimeDbContextFactory<CryptoTestContext>
    {
        public CryptoTestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CryptoTestContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=CryptoTest;MultipleActiveResultSets=true;Trusted_Connection=true;TrustServerCertificate=True");
            return new CryptoTestContext(optionsBuilder.Options);
        }
    }
}
