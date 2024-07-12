using MotoPlanck.Application.Core.Rentals.Commands.CreateRent;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Mappings
{
    internal static class RentMappingExtensions
    {
        internal async static Task<Rent> ToEntityAsync(this CreateRentCommand command, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var motorcycle = await unitOfWork.Motorcycles.GetByIdAsync(command.MotorcycleId, cancellationToken);
            var deliveryman = await unitOfWork.Deliverymans.GetByIdAsync(command.DeliverymanId, cancellationToken);
            var plan = await unitOfWork.Plans.GetByIdAsync(command.PlanId, cancellationToken);

            return new Rent(
                command.InitialDate,
                command.FinalDate,
                command.ForecastDate,
                deliveryman.Value,
                motorcycle.Value,
                plan.Value);
        }
    }
}
