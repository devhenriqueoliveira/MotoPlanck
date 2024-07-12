using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetUsers
{
    public sealed record class GetUsersQuery : IQuery<Result<IEnumerable<UserResponse>>>;
}
