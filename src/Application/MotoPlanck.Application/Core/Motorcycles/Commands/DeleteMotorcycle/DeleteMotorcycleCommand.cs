using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.DeleteMotorcycle
{
    public sealed record DeleteMotorcycleCommand(Guid Id) : ICommand<Result>;
}
