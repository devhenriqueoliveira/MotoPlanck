using MotoPlanck.Application.Core.Authentications.Contracts.Responses;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Application.Core.Users.Commands.CreateUser;
using MotoPlanck.Application.Core.Users.Commands.UpdateUser;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Domain.Repositories;

namespace MotoPlanck.Application.Mappings
{
    internal static class UserMappingExtensions
    {
        /// <summary>
        /// Represents the extension method to convert the IEnumerable of User to IEnumerable of UserResponse.
        /// </summary>
        /// <param name="users">The IEnumerable of User</param>
        /// <returns>Returns a IEnumerable of UserResponse</returns>
        internal static IEnumerable<UserResponse> ToUserResponse(this IEnumerable<User> users)
        {
            return users.Select(u => u.ToUserResponse());
        }

        /// <summary>
        /// Represents the extension method to convert the User to UserResponse.
        /// </summary>
        /// <param name="user">The entity of user</param>
        /// <returns>Return a UserReponse</returns>
        internal static UserResponse ToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Role = new RoleResponse
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name,
                    Description = user.Role.Description,
                    Active = user.Role.Active
                }
            };
        }
        internal static LoginAuthenticationResponse ToLoginAuthenticationResponse(this User user)
        {
            return new LoginAuthenticationResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Role = user.Role.Name
            };
        }

        /// <summary>
        /// Represents the extension method to convert the CreateUserCommand to User entity.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a result user entity.</returns>
        internal async static Task<Result<User>> ToEntityAsync(this CreateUserCommand command, IRoleRepository repository, CancellationToken cancellationToken)
        {
            var role = await repository.GetByIdAsync(command.RoleId, cancellationToken);

            if (role.IsFailure)
                return Result.Failure<User>(ValidationErros.Role.CreateRoleOnDatabase);

            return Result.Success(new User(
                command.FirstName, 
                command.LastName, 
                command.Login, 
                command.Password, 
                command.Email, 
                command.BirthDate, 
                role.Value));
        }

        internal async static Task<Result<User>> ToEntityAsync(this UpdateUserCommand command, IRoleRepository repository, CancellationToken cancellationToken)
        {
            var role = await repository.GetByIdAsync(command.RoleId, cancellationToken);

            if (role.IsFailure)
                return Result.Failure<User>(ValidationErros.Role.CreateRoleOnDatabase);

            return Result.Success(new User(
                command.Id,
                command.FirstName,
                command.LastName,
                command.Login,
                command.Password,
                command.Email,
                command.BirthDate,
                role.Value));
        }
    }
}
