using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Plans.Contracts.Responses;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Plans.Queries.GetPlanById
{
    internal sealed class GetPlanByIdHandler(
        IMapper mapper,
        ILogger<GetPlanByIdHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetPlanByIdQuery, Result<PlanResponse>>
    {

        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetPlanByIdHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        #region Handlers
        public async Task<Result<PlanResponse>> Handle(GetPlanByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to get plan by id.");

            var plan = await _unitOfWork.Plans.GetByIdAsync(query.Id, cancellationToken);

            if (plan.IsFailure)
                return Result.Failure<PlanResponse>(ValidationErros.Plan.GetPlanByIdOnDatabase);

            var response = _mapper.Map<PlanResponse>(plan.Value);

            return Result.Success(response);
        }

        #endregion
    }
}
