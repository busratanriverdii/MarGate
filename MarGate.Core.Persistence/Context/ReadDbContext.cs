using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.Persistence.Context;
public class ReadDbContext(DbContextOptions<ReadDbContext> options) : BaseDbContext<ReadDbContext>(options)
{
}
