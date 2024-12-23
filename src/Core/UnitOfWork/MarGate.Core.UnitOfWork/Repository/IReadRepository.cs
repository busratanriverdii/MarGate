using MarGate.Core.DDD;

namespace MarGate.Core.Persistence.Repository;
public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
{
}

