using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Queries.GetDeliverymans
{
    public sealed record GetDeliverymansQuery : IQuery<Result<IEnumerable<DeliverymanResponse>>>;
}
