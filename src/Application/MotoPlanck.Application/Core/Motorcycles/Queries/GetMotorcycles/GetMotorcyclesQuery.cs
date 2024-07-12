using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycles
{
    public sealed record GetMotorcyclesQuery() : IQuery<Result<IEnumerable<MotorcycleResponse>>>;
}
