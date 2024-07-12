using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Commands.UpdatePlan
{
    internal sealed class UpdatePlanHandler(
        IMapper mapper,
        ILogger<UpdatePlanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<UpdatePlanCommand, Result>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UpdatePlanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion

        public async Task<Result> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to update a plan.");

            var entity = _mapper.Map<Plan>(command);
            var response = await _unitOfWork.Plans.UpdateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Plan.UpdatePlanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
