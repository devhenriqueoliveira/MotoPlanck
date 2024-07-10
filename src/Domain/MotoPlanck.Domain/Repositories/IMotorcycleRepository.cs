using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Domain.Interfaces
{
    public interface IMotorcycleRepository : IGenericRepository<Motorcycle>
    {
        Task<Result> ExistsPlateAsync(string plate, CancellationToken cancellationToken);
        Task<Result> UpdatePlateByIdAsync(Guid id, string plate, CancellationToken cancellationToken);
    }
}
