using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleByPlate
{
    internal sealed class GetMotorcycleByPlateHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetMotorcycleByPlateHandler> logger) : IQueryHandler<GetMotorcycleByPlateQuery, Result<MotorcycleResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<GetMotorcycleByPlateHandler> _logger = logger;

        public async Task<Result<MotorcycleResponse>> Handle(GetMotorcycleByPlateQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the proccess to get motorcycle by plate.");

            var motorcycle = await _unitOfWork.Motorcycles.GetByPlateAsync(query.Plate, cancellationToken);

            if (motorcycle.IsFailure)
                return Result.Failure<MotorcycleResponse>(motorcycle.Error);

            var response = motorcycle.Value.ToMotorcycleResponse();

            _logger.LogInformation("Process realized with success.");

            return Result.Success(response!);
        }
    }
}
