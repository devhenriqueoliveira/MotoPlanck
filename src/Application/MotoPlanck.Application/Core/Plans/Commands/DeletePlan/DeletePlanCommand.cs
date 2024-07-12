using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.DeletePlan
{
    /// <summary>
    /// Represents the command to delete a plan.
    /// </summary>
    /// <param name="Id"></param>
    public sealed record DeletePlanCommand(Guid Id) : ICommand<Result>;
}
