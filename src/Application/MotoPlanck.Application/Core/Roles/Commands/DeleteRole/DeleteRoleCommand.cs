using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.DeleteRole
{
    /// <summary>
    /// Represents the command of delete role.
    /// </summary>
    /// <param name="Id">The identificator of role.</param>
    public sealed record DeleteRoleCommand(Guid Id) : ICommand<Result>;
}
