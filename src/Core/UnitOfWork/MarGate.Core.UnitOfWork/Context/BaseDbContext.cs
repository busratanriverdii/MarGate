using Microsoft.EntityFrameworkCore;

namespace MarGate.Core.UnitOfWork.Context;
public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
}

