using MarGate.Core.DDD;

namespace MarGate.Core.UnitOfWork.Repository;
public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    bool Create(T model);
    bool Update(T model);
    bool Delete(T model);
}
