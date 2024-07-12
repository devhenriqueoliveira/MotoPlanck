using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Domain.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<bool> ExistsRoleAsync(Guid id, CancellationToken cancellationToken);
    }
}
