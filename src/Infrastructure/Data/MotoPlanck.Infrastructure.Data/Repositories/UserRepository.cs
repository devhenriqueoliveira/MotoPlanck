using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Users;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Users;
using MotoPlanck.Infrastructure.Data.Extensions;
using MotoPlanck.Infrastructure.Data.Extensions.Users;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    internal sealed class UserRepository(
        IDatabaseContext context) : IUserRepository
    {
        private readonly IDatabaseContext _context = context;

        public async Task<Result> CreateAsync(User entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(UserCommandConstants.CREATE_USER, entity.MapFromParameters(), _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<User>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var records = await _context.Connection.QueryAsync<User>(UserQueryConstants.GET_ALL_USERS, _context.Transaction);

            if (records == default)
                return Result.Failure<IEnumerable<User>>(RepositoryExtensions.SelectedWithError);

            var userDictionary = new Dictionary<Guid, User>();

            var users = await _context.Connection.QueryAsync<User, Role, User>(
                UserQueryConstants.GET_ALL_USERS,
                (user, role) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                    {
                        currentUser = user;
                        userDictionary.Add(currentUser.Id, currentUser);
                    }

                    currentUser.SetRole(role);
                    return currentUser;
                },
                splitOn: "RoleId"
            );

            return Result.Success(users.Distinct());
        }

        public Task<Result<User>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
