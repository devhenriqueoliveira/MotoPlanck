using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.DeleteMotorcycle
{
    internal sealed class DeleteMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<DeleteMotorcycleHandler> logger) : ICommandHandler<DeleteMotorcycleCommand, Result>
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<DeleteMotorcycleHandler> _logger = logger;

        public async Task<Result> Handle(DeleteMotorcycleCommand command, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Starting the process to delete a motorcycle.");

            var response = await _unitOfWork.Motorcycles.DeleteAsync(command.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Process realized with success.");

            return Result.Success();
        }
    }
}
