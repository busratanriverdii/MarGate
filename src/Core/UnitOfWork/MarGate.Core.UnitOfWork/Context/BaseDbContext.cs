using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.Persistence.Context;
public class BaseDbContext<TContext>(DbContextOptions<TContext> options) : DbContext(options) where TContext : DbContext
{
}

