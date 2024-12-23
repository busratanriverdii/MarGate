using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Identity.Persistence.Contexts
{
    public class OrderDesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Order;User=sa;Password=Password123;Encrypt=false");

            return new OrderDbContext(optionsBuilder.Options);
        }
    }

}
