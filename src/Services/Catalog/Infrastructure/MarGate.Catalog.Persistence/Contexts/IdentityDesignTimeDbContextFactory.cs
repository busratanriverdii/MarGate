using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MarGate.Catalog.Persistence.Contexts;

namespace MarGate.Identity.Persistence.Contexts
{
    public class CatalogDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Catalog;User=sa;Password=Password123;Encrypt=false");

            return new CatalogDbContext(optionsBuilder.Options);
        }
    }

}
