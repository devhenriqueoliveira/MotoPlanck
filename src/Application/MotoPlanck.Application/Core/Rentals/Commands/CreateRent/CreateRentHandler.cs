using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Rentals.Commands.CreateRent
{
    internal sealed class CreateRentHandler(
        ILogger<CreateRentHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateRentCommand, Result>
    {
        #region Fields

        private readonly ILogger<CreateRentHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion
        public async Task<Result> Handle(CreateRentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to create a plan.");

            var entity = await command.ToEntityAsync(_unitOfWork, cancellationToken);
            var response = await _unitOfWork.Rentals.CreateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Plan.CreatePlanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
