using MarGate.Core.DDD;
using MarGate.Core.UnitOfWork.Context;
using MarGate.Core.UnitOfWork.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Core.UnitOfWork.UnitOfWork;
public class UnitOfWork(IServiceProvider serviceProvider) : IUnitOfWork
{
    private readonly DbContext _writeDbContext = serviceProvider.GetService<WriteDbContext>();
    private readonly DbContext _readDbContext = (DbContext)serviceProvider.GetService<ReadDbContext>()
        ?? serviceProvider.GetService<WriteDbContext>();

    public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity
    {
        return new WriteRepository<T>(_writeDbContext);
    }

    public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity
    {
        return new ReadRepository<T>(_readDbContext);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _writeDbContext.SaveChangesAsync(cancellationToken);
    }
}
