using MarGate.Core.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Basket.Persistence.Contexts
{
    public class BasketDbContext(DbContextOptions<BasketDbContext> options) : WriteDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}