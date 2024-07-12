using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.CreatePlan
{
    internal sealed class CreatePlanHandler(
        IMapper mapper,
        ILogger<CreatePlanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<CreatePlanCommand, Result>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreatePlanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion

        #region Handlers
        public async Task<Result> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to create a plan.");

            var entity = _mapper.Map<Plan>(command);
            var response = await _unitOfWork.Plans.CreateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Plan.CreatePlanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        #endregion
    }
}
