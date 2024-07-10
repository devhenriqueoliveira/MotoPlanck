using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Queries.GetByIdRole
{
    /// <summary>
    /// Represents the query of get role by id.
    /// </summary>
    /// <param name="Id">The identificator of role.</param>
    public sealed record GetRoleByIdQuery(Guid Id) : IQuery<Result<RoleResponse>>;
}
