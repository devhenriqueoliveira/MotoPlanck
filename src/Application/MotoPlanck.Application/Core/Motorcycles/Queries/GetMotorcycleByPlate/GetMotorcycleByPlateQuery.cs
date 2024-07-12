using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleByPlate
{
    public sealed record GetMotorcycleByPlateQuery(string Plate) : IQuery<Result<MotorcycleResponse>>;
}
