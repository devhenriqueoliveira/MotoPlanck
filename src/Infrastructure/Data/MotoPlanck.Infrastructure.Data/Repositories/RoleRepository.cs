using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Roles;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Roles;
using MotoPlanck.Infrastructure.Data.Extensions;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Responsible for database operations
    /// </summary>
    /// <param name="context">The database context</param>
    internal sealed class RoleRepository(IDatabaseContext context) : IRoleRepository
    {
        #region Fields

        private readonly IDatabaseContext _context = context;

        #endregion

        #region Commands
        public async Task<Result> CreateAsync(Role entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(RoleCommandConstants.CREATE_ROLE, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(RoleCommandConstants.DELETE_ROLE, new { Id = id }, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Role entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(RoleCommandConstants.UPDATE_ROLE, entity, _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        #endregion

        #region Queries
        public async Task<Result<IEnumerable<Role>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var roles = await _context.Connection.QueryAsync<Role>(RoleQueryConstants.GET_ALL_ROLES, _context.Transaction);
            return Result.Success(roles);
        }

        public async Task<Result<Role>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var role = await _context.Connection.QuerySingleAsync<Role>(RoleQueryConstants.GET_ROLE_BY_ID, new { Id = id }, _context.Transaction);
            return Result.Success(role);
        }

        public async Task<bool> ExistsIdentificator(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(RoleQueryConstants.EXISTS_IDENTIFICATOR, new { Id = id }, _context.Transaction);
        }

        #endregion
    }
}
