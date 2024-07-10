using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.UpdateRole
{
    /// <summary>
    /// Represents the command for update a role.
    /// </summary>
    /// <param name="Id">The identificator of role.</param>
    /// <param name="Name">The name of role.</param>
    /// <param name="Description">The description of role.</param>
    /// <param name="Active">The active status of role.</param>
    public sealed record class UpdateRoleCommand(
        Guid Id,
        string Name,
        string Description,
        bool Active) : ICommand<Result>;
}
