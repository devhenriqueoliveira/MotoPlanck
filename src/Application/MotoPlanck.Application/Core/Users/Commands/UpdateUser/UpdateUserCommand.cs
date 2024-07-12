using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.UpdateUser
{
    /// <summary>
    /// Represents the command for updating a user.
    /// </summary>
    /// <param name="Id">The identificator of user.</param>
    /// <param name="FirstName">The first name of user.</param>
    /// <param name="LastName">The last name of user.</param>
    /// <param name="Login">The login of user.</param>
    /// <param name="Password">The password of user.</param>
    /// <param name="Email">The email of user.</param>
    /// <param name="BirthDate">The birth date of user.</param>
    /// <param name="Role">The role of user.</param>
    public sealed record UpdateUserCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string Login,
        string Password,
        string Email,
        DateTime BirthDate,
        Guid RoleId) : ICommand<Result>;
}
