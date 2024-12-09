using MarGate.Core.Persistence.Context;
using MarGate.Core.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace MarGate.Core.Persistence.UnitOfWork;
public class UnitOfWork(IServiceProvider serviceProvider) : IUnitOfWork
{
    private readonly ConcurrentDictionary<string, DbContext> _dbContextCache = new ConcurrentDictionary<string, DbContext>();

    public IWriteRepository<T> GetWriteRepository<T>() where T : class
    {
        var writeDbContext = (WriteDbContext)_dbContextCache.GetOrAdd(nameof(WriteDbContext), type =>
        {
            return serviceProvider.GetRequiredService<WriteDbContext>();
        });

        return new WriteRepository<T>(writeDbContext);
    }

    public IReadRepository<T> GetReadRepository<T>() where T : class
    {
        var readDbContext = (ReadDbContext)_dbContextCache.GetOrAdd(nameof(ReadDbContext), type =>
        {
            return serviceProvider.GetRequiredService<ReadDbContext>();
        });

        return new ReadRepository<T>(readDbContext);
    }
}
