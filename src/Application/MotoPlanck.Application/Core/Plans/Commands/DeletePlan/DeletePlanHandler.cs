using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.DeletePlan
{
    internal sealed class DeletePlanHandler(
        IMapper mapper,
        ILogger<DeletePlanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<DeletePlanCommand, Result>
    {

        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<DeletePlanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        #region Handlers
        public async Task<Result> Handle(DeletePlanCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to delete a plan.");

            var response = await _unitOfWork.Plans.DeleteAsync(command.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Plan.DeletePlanOnDatabase);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Plan deleted with success.");

            return Result.Success();
        }

        #endregion
    }
}
