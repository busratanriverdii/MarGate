using MarGate.Core.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Payment.Persistence.Contexts
{
    public class PaymentDbContext(DbContextOptions<PaymentDbContext> options) : WriteDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}