using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Rentals.Commands.CreateRent
{
    public sealed record CreateRentCommand(
        DateTime InitialDate,
        DateTime FinalDate,
        DateTime ForecastDate,
        Guid DeliverymanId,
        Guid PlanId,
        Guid MotorcycleId) : ICommand<Result>;
}
