using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.DeleteDeliveryman
{
    /// <summary>
    /// Represents the command to delete deliveryman
    /// </summary>
    /// <param name="Id">The identificator of deliveryman</param>
    public sealed record DeleteDeliverymanCommand(Guid Id) : ICommand<Result>;
}
