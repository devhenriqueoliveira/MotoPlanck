using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Application.Abstractions.Messaging;
using Microsoft.Extensions.Logging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Application.Core.Motorcycles.Contracts;
using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;

namespace MotoPlanck.Application.Core.Motorcycles.Queries.GetAllMotorcycle
{
    internal sealed class GetAllMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateMotorcycleHandler> logger) : IQueryHandler<GetAllMotorcycleQuery, Result<IEnumerable<MotorcycleResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreateMotorcycleHandler> _logger = logger;

        public async Task<Result<IEnumerable<MotorcycleResponse>>> Handle(GetAllMotorcycleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando...");

            var result = await _unitOfWork.Motorcycles.GetAllAsync(cancellationToken);
            var response = result.Value.Select(x => new MotorcycleResponse() { Id = x.Id, Model = x.Model, Plate = x.Plate, Year = x.Year });

            _logger.LogInformation("Selecionado com sucesso...");

            return Result.Success(response);
        }
    }
}
