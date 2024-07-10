using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Queries.GetAllRole
{
    /// <summary>
    /// Represents the query of get all roles.
    /// </summary>
    public sealed record GetAllRoleQuery : IQuery<Result<IEnumerable<RoleResponse>>>;
}
