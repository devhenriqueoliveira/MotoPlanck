using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle
{
    /// <summary>
    /// Represents the command for creating a motorcycle.
    /// </summary>
    /// <param name="Year">The year of motorcycle</param>
    /// <param name="Model">The model of motorcycle</param>
    /// <param name="Plate">The plate of motorcycle</param>
    public sealed record CreateMotorcycleCommand(
        int Year,
        string Model,
        string Plate) : ICommand<Result>;
}
