using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    internal class DeliverymanRepository : IDeliverymanRepository
    {
        public Task<Result> CreateAsync(Deliveryman entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Deliveryman>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Deliveryman>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(Deliveryman entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
