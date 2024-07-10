using MediatR;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.UpdateMotorcycle
{
    /// <summary>
    /// Represents the <see cref="UpdateMotorcycleCommand"/> handler.
    /// </summary>
    internal sealed class UpdateMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateMotorcycleHandler> logger) : ICommandHandler<UpdateMotorcycleCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreateMotorcycleHandler> _logger = logger;

        public async Task<Result> Handle(UpdateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando...");

            await _unitOfWork.Motorcycles.UpdatePlateByIdAsync(command.Id, command.Plate, cancellationToken);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Atualizado com sucesso...");

            return Result.Success();
        }
    }
}
