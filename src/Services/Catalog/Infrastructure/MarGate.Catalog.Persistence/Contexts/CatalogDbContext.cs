using MarGate.Core.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Catalog.Persistence.Contexts
{
    public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : WriteDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}