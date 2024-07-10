using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetAllUser
{
    public sealed record class GetAllUserQuery : IQuery<Result<IEnumerable<UserResponse>>>;
}
