using MarGate.Core.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Identity.Persistence.Contexts
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options) : WriteDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}