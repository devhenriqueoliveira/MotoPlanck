using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Plans.Contracts.Responses;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Queries.GetPlans
{
    /// <summary>
    /// Represents the query to get plans.
    /// </summary>
    public sealed record GetPlansQuery : IQuery<Result<IEnumerable<PlanResponse>>>;
}
