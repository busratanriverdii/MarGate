namespace MarGate.Core.Persistence.Repository;
public interface IWriteRepository<T> : IBaseRepository<T> where T : class
{
    Task CreateAsync(T model);  
    void Update(T model);
    void Delete(T model);
}
