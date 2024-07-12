using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Plans.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Queries.GetPlanById
{
    /// <summary>
    /// Represents the query to get plan by id.
    /// </summary>
    /// <param name="Id">The identificator of plan</param>
    public sealed record GetPlanByIdQuery(Guid Id) : IQuery<Result<PlanResponse>>;
}
