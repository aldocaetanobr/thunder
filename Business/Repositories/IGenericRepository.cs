using Models;

namespace Business.Repositories
{
    public interface IGenericRepository<T> where T : BaseDbModel
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
    }
}