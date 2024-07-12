using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Plans.Contracts.Responses;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Queries.GetPlans
{
    internal sealed class GetPlansHandler(
        IMapper mapper,
        ILogger<GetPlansHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetPlansQuery, Result<IEnumerable<PlanResponse>>>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetPlansHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion
        public async Task<Result<IEnumerable<PlanResponse>>> Handle(GetPlansQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to get plans.");

            var plans = await _unitOfWork.Plans.GetAllAsync(cancellationToken);
            
            if (plans.IsFailure)
                return Result.Failure<IEnumerable<PlanResponse>>(ValidationErros.Plan.GetPlansOnDatabase);

            var response = _mapper.Map<IEnumerable<PlanResponse>>(plans.Value);

            return Result.Success(response);
        }
    }
}
