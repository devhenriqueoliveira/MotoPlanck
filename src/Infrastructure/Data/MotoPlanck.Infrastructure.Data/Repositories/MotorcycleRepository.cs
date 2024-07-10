using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Motorcycles;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Motorcycles;
using MotoPlanck.Infrastructure.Data.Extensions;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    internal sealed class MotorcycleRepository(
        IDatabaseContext context) : IMotorcycleRepository
    {
        #region Fields

        private readonly IDatabaseContext _context = context;

        #endregion

        #region Commands
        public async Task<Result> CreateAsync(Motorcycle entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(MotorcycleCommandConstants.CREATE_MOTORCYCLE, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(MotorcycleCommandConstants.DELETE_MOTORCYCLE, new { Id = id }, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.DeletedWithError);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Motorcycle entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(MotorcycleCommandConstants.UPDATE_MOTORCYCLE, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }
        public async Task<Result> UpdatePlateByIdAsync(Guid id, string plate, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(MotorcycleCommandConstants.UPDATE_MOTORCYCLE, new { Id = id, Plate = plate }, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }
        #endregion

        #region Queries
        public async Task<Result> ExistsPlateAsync(string plate, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.QuerySingleOrDefaultAsync<int>(MotorcycleQueryConstants.EXISTS_PLATE_MOTORCYCLE, new { Plate = plate }, _context.Transaction);

            if (records == default)
                return Result.Failure(RepositoryExtensions.SelectedWithError);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<Motorcycle>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var records = await _context.Connection.QueryAsync<Motorcycle>(MotorcycleQueryConstants.GET_ALL_MOTORCYCLE, _context.Transaction);

            if (records == default)
                return Result.Failure<IEnumerable<Motorcycle>>(RepositoryExtensions.SelectedWithError);

            return Result.Success(records);
        }

        public async Task<Result<Motorcycle>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.QueryFirstOrDefaultAsync<Motorcycle>(MotorcycleQueryConstants.GET_BY_ID_MOTORCYCLE, new { Id = id }, _context.Transaction);

            if (records is null)
                return Result.Failure<Motorcycle>(RepositoryExtensions.SelectedWithError);

            return Result.Success(records);
        }

        #endregion
    }
}
