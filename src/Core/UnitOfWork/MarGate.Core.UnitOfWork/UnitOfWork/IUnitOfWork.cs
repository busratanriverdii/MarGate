using MarGate.Core.DDD;
using MarGate.Core.Persistence.Repository;

namespace MarGate.Core.Persistence.UnitOfWork;
public interface IUnitOfWork
{
    public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;

    public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
