using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MarGate.Identity.Persistence.Contexts
{
    public class IdentityDesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Identity;User=sa;Password=Password123;Encrypt=false");

            return new IdentityDbContext(optionsBuilder.Options);
        }
    }

}
