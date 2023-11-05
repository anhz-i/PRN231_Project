using System.Linq.Expressions;

namespace Repositories.IRepositories
{
    public interface IRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync();                        
        Task<T?> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);                
    }
}