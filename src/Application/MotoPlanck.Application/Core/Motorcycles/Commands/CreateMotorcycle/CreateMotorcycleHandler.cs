using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Mappings;
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
        public async Task<Result> Handle(CreateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to create a motorcycle.");

            var response = await _unitOfWork.Motorcycles.CreateAsync(command.ToEntity(), cancellationToken);
            
            if(response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Process realized with success.");

            return Result.Success();
        }
    }
}
