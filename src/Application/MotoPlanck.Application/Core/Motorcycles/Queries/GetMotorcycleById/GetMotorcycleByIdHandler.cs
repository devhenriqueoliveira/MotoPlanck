using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleById
{
    internal sealed class GetMotorcycleByIdHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetMotorcycleByIdHandler> logger) : IQueryHandler<GetMotorcycleByIdQuery, Result<MotorcycleResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<GetMotorcycleByIdHandler> _logger = logger;

        public async Task<Result<MotorcycleResponse>> Handle(GetMotorcycleByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the proccess to get motorcycles.");

            var motorcycles = await _unitOfWork.Motorcycles.GetByIdAsync(query.Id, cancellationToken);

            if (motorcycles.IsFailure)
                return Result.Failure<MotorcycleResponse>(motorcycles.Error);

            var response = motorcycles.Value.ToMotorcycleResponse();

            _logger.LogInformation("Process realized with success.");

            return Result.Success(response);
        }
    }
}
