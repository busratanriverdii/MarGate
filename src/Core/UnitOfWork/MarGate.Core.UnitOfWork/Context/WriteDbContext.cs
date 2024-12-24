using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.UnitOfWork.Context;
public class WriteDbContext(DbContextOptions options) : BaseDbContext(options)
{
}
