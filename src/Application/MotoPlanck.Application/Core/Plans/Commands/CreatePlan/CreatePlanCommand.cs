using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.CreatePlan
{
    public sealed record class CreatePlanCommand(
        int Day,
        decimal Amount,
        int RatePercentage) : ICommand<Result>;
}
