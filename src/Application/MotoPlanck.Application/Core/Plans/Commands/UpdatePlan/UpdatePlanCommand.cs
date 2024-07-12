using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.UpdatePlan
{
    public sealed record class UpdatePlanCommand(
        Guid Id,
        int Day,
        decimal Amount,
        int RatePercentage) : ICommand<Result>;
}
