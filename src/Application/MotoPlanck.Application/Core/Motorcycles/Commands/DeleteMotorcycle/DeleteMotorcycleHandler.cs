using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.DeleteMotorcycle
{
    internal sealed class DeleteMotorcycleHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateMotorcycleHandler> logger) : ICommandHandler<DeleteMotorcycleCommand, Result>
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreateMotorcycleHandler> _logger = logger;

        public async Task<Result> Handle(DeleteMotorcycleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando...");

            await _unitOfWork.Motorcycles.DeleteAsync(command.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Deletado com sucesso...");

            return Result.Success();
        }
    }
}
