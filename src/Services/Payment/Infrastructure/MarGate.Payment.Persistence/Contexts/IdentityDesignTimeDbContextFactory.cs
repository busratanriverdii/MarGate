using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MarGate.Payment.Persistence.Contexts;

namespace MarGate.Payment.Persistence.Contexts
{
    public class IdentityDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaymentDbContext>
    {
        public PaymentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Payment;User=sa;Password=Password123;Encrypt=false");

            return new PaymentDbContext(optionsBuilder.Options);
        }
    }

}
