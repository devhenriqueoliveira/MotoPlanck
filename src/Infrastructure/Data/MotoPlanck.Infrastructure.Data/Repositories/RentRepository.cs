using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    internal sealed class RentRepository : IRentRepository
    {
        public Task<Result> CreateAsync(Rent entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Rent>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Rent>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(Rent entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
