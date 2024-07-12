using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Application.Mappings
{
    internal static class MotorcycleMappingExtensions
    {
        internal static Motorcycle ToEntity(this CreateMotorcycleCommand command)
        {
            return new Motorcycle(command.Model, command.Plate, command.Year);
        }

        internal static IEnumerable<MotorcycleResponse> ToMotorcycleResponse(this IEnumerable<Motorcycle> motorcycle)
        {
            return motorcycle.Select(m => m.ToMotorcycleResponse());
        }

        internal static MotorcycleResponse? ToMotorcycleResponse(this Motorcycle motorcycle)
        {
            if (motorcycle is null)
                return null;

            return new MotorcycleResponse() 
            { 
                Id = motorcycle.Id,
                Model = motorcycle.Model,
                Plate = motorcycle.Plate,
                Year = motorcycle.Year
            };
        }
    }
}
