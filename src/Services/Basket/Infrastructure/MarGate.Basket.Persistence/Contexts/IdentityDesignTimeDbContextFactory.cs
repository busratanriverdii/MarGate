using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MarGate.Basket.Persistence.Contexts;

namespace MarGate.Identity.Persistence.Contexts
{
    public class BasketDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BasketDbContext>
    {
        public BasketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BasketDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Basket;User=sa;Password=Password123;Encrypt=false");

            return new BasketDbContext(optionsBuilder.Options);
        }
    }

}
