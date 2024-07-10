using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Queries.GetDeliverymanById
{
    /// <summary>
    /// Represents the query to get deliveryman by id
    /// </summary>
    /// <param name="Id">The id of deliveryman</param>
    public sealed record GetDeliverymanByIdQuery(Guid Id) : IQuery<Result<DeliverymanResponse>>;
}
