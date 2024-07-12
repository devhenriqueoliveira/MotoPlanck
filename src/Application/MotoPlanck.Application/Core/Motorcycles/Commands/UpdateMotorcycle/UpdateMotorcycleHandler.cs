using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.UpdateMotorcycle
{
    /// <summary>
    /// Represents the <see cref="UpdateMotorcycleCommand"/> handler.
    /// </summary>
    internal sealed class UpdateMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<UpdateMotorcycleHandler> logger) : ICommandHandler<UpdateMotorcycleCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<UpdateMotorcycleHandler> _logger = logger;

        public async Task<Result> Handle(UpdateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to update a motorcycle.");

            var response = await _unitOfWork.Motorcycles.UpdatePlateByIdAsync(command.Id, command.Plate, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Process realized with success.");

            return Result.Success();
        }
    }
}
