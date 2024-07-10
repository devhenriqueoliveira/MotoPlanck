using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Domain.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<bool> ExistsIdentificator(Guid id, CancellationToken cancellationToken);
    }
}
