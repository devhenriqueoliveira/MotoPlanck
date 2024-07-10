using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.CreateRole
{
    /// <summary>
    /// Represents the command for creating a role.
    /// </summary>
    /// <param name="Name">The name of role.</param>
    /// <param name="Description">The description of role.</param>
    /// <param name="Active">A validation to check if the role is active.</param>
    public sealed record CreateRoleCommand(
        string Name,
        string Description,
        bool Active) : ICommand<Result>;
}
