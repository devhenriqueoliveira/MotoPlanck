using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Application.Abstractions.Messaging;
using Microsoft.Extensions.Logging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Responses;
using MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycles;
using MotoPlanck.Application.Mappings;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetAllMotorcycle
{
    internal sealed class GetMotorcyclesHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetMotorcyclesHandler> logger) : IQueryHandler<GetMotorcyclesQuery, Result<IEnumerable<MotorcycleResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<GetMotorcyclesHandler> _logger = logger;

        public async Task<Result<IEnumerable<MotorcycleResponse>>> Handle(GetMotorcyclesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the proccess to get motorcycles.");

            var motorcycles = await _unitOfWork.Motorcycles.GetAllAsync(cancellationToken);

            if(motorcycles.IsFailure)
                return Result.Failure<IEnumerable<MotorcycleResponse>>(motorcycles.Error);

            var response = motorcycles.Value.ToMotorcycleResponse();

            _logger.LogInformation("Process realized with success.");

            return Result.Success(response);
        }
    }
}
