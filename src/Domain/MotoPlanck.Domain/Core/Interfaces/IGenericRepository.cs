using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Domain.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<Result> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
