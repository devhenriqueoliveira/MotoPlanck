using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    internal sealed class PlanRepository : IPlanRepository
    {
        public Task<Result> CreateAsync(Plan entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Plan>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Plan>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(Plan entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
