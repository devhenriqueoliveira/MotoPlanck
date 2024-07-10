using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle
{
    /// <summary>
    /// Represents the <see cref="CreateMotorcycleCommand"/> handler.
    /// </summary>
    internal sealed class CreateMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateMotorcycleHandler> logger) : ICommandHandler<CreateMotorcycleCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreateMotorcycleHandler> _logger = logger;
        public async Task<Result> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando...");

            await _unitOfWork.Motorcycles.CreateAsync(new Motorcycle(request.Model, request.Plate, request.Year), cancellationToken);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Criado com sucesso...");

            return Result.Success();
        }
    }
}
