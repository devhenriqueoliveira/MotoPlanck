using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Domain.Repositories
{
    public interface IPlanRepository : IGenericRepository<Plan>
    {
        Task<bool> ExistsPlanById(Guid id, CancellationToken cancellationToken);
    }
}
