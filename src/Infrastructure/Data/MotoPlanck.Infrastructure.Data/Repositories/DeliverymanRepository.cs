using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Deliverymans;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Deliverymans;
using MotoPlanck.Infrastructure.Data.Extensions;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Represents the repository of deliveryman
    /// </summary>
    /// <param name="context">The context of database</param>
    internal class DeliverymanRepository(IDatabaseContext context) : IDeliverymanRepository
    {
        #region Fields

        private readonly IDatabaseContext _context = context;
        
        #endregion

        #region Commands
        public async Task<Result> CreateAsync(Deliveryman entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(DeliverymanCommandConstants.CREATE_DELIVERYMAN, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(DeliverymanCommandConstants.DELETE_DELIVERYMAN, new { Id = id }, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.DeletedWithError);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Deliveryman entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(DeliverymanCommandConstants.UPDATE_DELIVERYMAN, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }

        #endregion

        #region Queries
        public async Task<bool> ExistsCnhAsync(string cnh, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(DeliverymanQueryConstants.EXISTS_CNH, new { Cnh = cnh }, _context.Transaction);
        }

        public async Task<bool> ExistsCnpjAsync(string cnpj, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(DeliverymanQueryConstants.EXISTS_CNPJ, new { Cnpj = cnpj }, _context.Transaction);
        }

        public async Task<bool> ExistsDeliverymanAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(DeliverymanQueryConstants.EXISTS_DELIVERYMAN, new { Id = id }, _context.Transaction);
        }

        public Task<Result<IEnumerable<Deliveryman>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Deliveryman>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
