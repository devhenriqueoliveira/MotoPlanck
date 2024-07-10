using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetAllMotorcycle
{
    public sealed record GetAllMotorcycleQuery : IQuery<Result<IEnumerable<MotorcycleResponse>>>;
}
