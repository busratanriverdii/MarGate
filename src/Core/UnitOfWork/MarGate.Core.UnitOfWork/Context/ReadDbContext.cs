using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.UnitOfWork.Context;
public class ReadDbContext(DbContextOptions options) : BaseDbContext(options)
{
}
