using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Plans;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Plans;
using MotoPlanck.Infrastructure.Data.Extensions;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    internal sealed class PlanRepository(IDatabaseContext context) : IPlanRepository
    {
        private readonly IDatabaseContext _context = context;

        #region Commands
        public async Task<Result> CreateAsync(Plan entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(PlanCommandConstants.CREATE_PLAN, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Plan entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(PlanCommandConstants.UPDATE_PLAN, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(PlanCommandConstants.DELETE_PLAN, new { Id = id }, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }
        #endregion

        #region Queries
        public async Task<bool> ExistsPlanById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(PlanQueryConstants.EXISTS_PLAN_BY_ID, new { Id = id }, _context.Transaction);
        }

        public async Task<Result<IEnumerable<Plan>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var plans = await _context.Connection.QueryAsync<Plan>(PlanQueryConstants.GET_PLANS, _context.Transaction);
            return Result.Success(plans);
        }

        public async Task<Result<Plan>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var plans = await _context.Connection.QuerySingleOrDefaultAsync<Plan>(PlanQueryConstants.GET_PLAN_BY_ID, new { Id = id }, _context.Transaction);
            return Result.Success(plans!);
        } 
        #endregion
    }
}
