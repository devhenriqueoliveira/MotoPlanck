using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.DeleteDeliveryman
{
    /// <summary>
    /// Represents the <see cref="DeleteDeliverymanCommand"/> handler.
    /// </summary>
    /// <param name="logger">The logger of <see cref="DeleteDeliverymanHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories</param>
    internal sealed class DeleteDeliverymanHandler(
        ILogger<DeleteDeliverymanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteDeliverymanCommand, Result>
    {
        #region Fields
        private readonly ILogger<DeleteDeliverymanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(DeleteDeliverymanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to delete a deliveryman.");

            var response = await _unitOfWork.Deliverymans.DeleteAsync(request.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Deliveryman.DeleteDeliverymanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
        #endregion
    }
}
