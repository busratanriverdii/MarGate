using MarGate.Core.DDD;

namespace MarGate.Core.UnitOfWork.Repository;
public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
{
}

