using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.Persistence.Context;
public class WriteDbContext(DbContextOptions<WriteDbContext> options) : BaseDbContext<WriteDbContext>(options)
{
}
