using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.DeleteUser
{
    /// <summary>
    /// Represents the command to delete user.
    /// </summary>
    /// <param name="Id">The identificator of user.</param>
    public sealed record DeleteUserCommand(Guid Id) : ICommand<Result>;
}
