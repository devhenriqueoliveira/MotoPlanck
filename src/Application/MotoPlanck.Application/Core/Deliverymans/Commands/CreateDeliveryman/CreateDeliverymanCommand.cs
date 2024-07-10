using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman
{
    /// <summary>
    /// Represents the command to create a deliveryman
    /// </summary>
    /// <param name="Cnpj">The cnpj of deliveryman</param>
    /// <param name="Cnh">The cnh of deliveryman</param>
    /// <param name="TypeCnh">The type cnh of deliveryman</param>
    /// <param name="PictureCnhId">The picture cnh identificator of deliveryman</param>
    /// <param name="UserId">The user identificator of deliveryman</param>
    public sealed record CreateDeliverymanCommand(
        string Cnpj,
        string Cnh,
        string TypeCnh,
        string PictureCnhId,
        Guid UserId) : ICommand<Result>;
}
