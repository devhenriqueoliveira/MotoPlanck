using Dapper;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Constants.Commands.Users;
using MotoPlanck.Infrastructure.Data.Constants.Queries.Users;
using MotoPlanck.Infrastructure.Data.Extensions;
using MotoPlanck.Infrastructure.Data.Extensions.Users;
using MotoPlanck.Infrastructure.Data.Validations;

namespace MotoPlanck.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Represents the repository of user.
    /// </summary>
    /// <param name="context">The context of database.</param>
    internal sealed class UserRepository(
        IDatabaseContext context) : IUserRepository
    {
        #region Fields

        private readonly IDatabaseContext _context = context;
        #endregion

        #region Commands

        public async Task<Result> CreateAsync(User entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(UserCommandConstants.CREATE_USER, entity.MapFromParameters(), _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.CreatedWithError);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(UserCommandConstants.UPDATE_USER, entity.MapFromParameters(), _context.Transaction);

            if (records == 0)
                return Result.Failure(RepositoryExtensions.UpdatedWithError);

            return Result.Success();
        }

        /// <summary>
        /// Method to delete a user by id.
        /// </summary>
        /// <param name="id">The id of user.</param>
        /// <param name="cancellationToken">The token for operations that must be canceled.</param>
        /// <returns>Return a Result object with success or error.</returns>
        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var records = await _context.Connection.ExecuteAsync(UserCommandConstants.DELETE_USER, new { Id = id }, _context.Transaction);

            if (records == 0)
                return Result.Failure(ValidationErros.Database.DeletedWithError);

            return Result.Success();
        }
        #endregion

        #region Queries
       
        public async Task<bool> ExistsUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(UserQueryConstants.EXISTS_USER, new { Id = id }, _context.Transaction);
        }

        public async Task<bool> ExistsLoginAsync(string login, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(UserQueryConstants.EXISTS_LOGIN, new { Login = login.Trim() }, _context.Transaction);
        }

        public async Task<bool> ExistsEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Connection.QuerySingleAsync<bool>(UserQueryConstants.EXISTS_EMAIL, new { Email = email.Trim() }, _context.Transaction);
        }
        public async Task<Result<IEnumerable<User>>> GetAllAsync(CancellationToken cancellationToken)
        {
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

                    currentUser.CreateRole(role);
                    return currentUser;
                },
                splitOn: "RoleId"
            );

            return Result.Success(users.Distinct());
        }

        public async Task<Result<User>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var userDictionary = new Dictionary<Guid, User>();

            var users = await _context.Connection.QueryAsync<User, Role, User>(
                UserQueryConstants.GET_USER_BY_ID,
                (user, role) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                    {
                        currentUser = user;
                        userDictionary.Add(currentUser.Id, currentUser);
                    }

                    currentUser.CreateRole(role);
                    return currentUser;
                },
                new { Id = id },
                splitOn: "RoleId");

            return Result.Success(users.FirstOrDefault()!);
        }

        public async Task<Result<User>> GetUserByloginAsync(string login, CancellationToken cancellationToken)
        {
            var userDictionary = new Dictionary<Guid, User>();

            var users = await _context.Connection.QueryAsync<User, Role, User>(
                UserQueryConstants.GET_USER_BY_LOGIN,
                (user, role) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                    {
                        currentUser = user;
                        userDictionary.Add(currentUser.Id, currentUser);
                    }

                    currentUser.CreateRole(role);
                    return currentUser;
                },
                new { Login = login },
                splitOn: "RoleId");

            return Result.Success(users.FirstOrDefault()!);
        }

        #endregion
    }
}
