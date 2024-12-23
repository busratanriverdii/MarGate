using MarGate.Core.DDD;
using MarGate.Core.UnitOfWork.Repository;

namespace MarGate.Core.UnitOfWork.UnitOfWork;
public interface IUnitOfWork
{
    public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;

    public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
