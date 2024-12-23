using MarGate.Core.DDD;

namespace MarGate.Core.Persistence.Repository;
public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    long Create(T model);
    bool Update(T model);
    bool Delete(T model);
}
