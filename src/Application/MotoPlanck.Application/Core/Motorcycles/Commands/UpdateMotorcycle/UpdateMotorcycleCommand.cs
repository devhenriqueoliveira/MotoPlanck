using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.UpdateMotorcycle
{
    /// <summary>
    /// Represents the command to updating a motorcycle.
    /// </summary>
    /// <param name="Plate">The plate of motorcycle</param>
    public sealed record UpdateMotorcycleCommand(Guid Id, string Plate) : ICommand<Result>;
}
