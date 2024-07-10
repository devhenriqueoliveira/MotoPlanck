using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents the command for creating a user.
    /// </summary>
    /// <param name="FirstName">The first name of user.</param>
    /// <param name="LastName">The last name of user.</param>
    /// <param name="Login">The login of user.</param>
    /// <param name="Password">The password of user.</param>
    /// <param name="Email">The email of user.</param>
    /// <param name="BirthDate">The birth date of user.</param>
    /// <param name="Role">The role of user.</param>
    public sealed record CreateUserCommand(
        string FirstName,
        string LastName,
        string Login,
        string Password,
        string Email,
        DateTime BirthDate,
        Guid RoleId) : ICommand<Result>;
}
