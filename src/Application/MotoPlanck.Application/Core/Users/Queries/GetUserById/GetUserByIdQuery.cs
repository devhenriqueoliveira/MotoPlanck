using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetUserById
{
    /// <summary>
    /// Represents the query to get user by id.
    /// </summary>
    /// <param name="Id">The identificator of user</param>
    public sealed record GetUserByIdQuery(Guid Id) : IQuery<Result<UserResponse>>;
}
