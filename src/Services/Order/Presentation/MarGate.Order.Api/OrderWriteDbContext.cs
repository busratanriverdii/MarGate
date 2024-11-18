using MarGate.Core.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class OrderWriteDbContext : WriteDbContext
{
    public OrderWriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }
}