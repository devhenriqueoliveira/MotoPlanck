using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleById
{
    public sealed record GetMotorcycleByIdQuery(Guid Id)  :IQuery<Result<MotorcycleResponse>>;
}
