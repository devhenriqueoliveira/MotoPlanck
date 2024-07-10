using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.DeleteDeliveryman
{
    internal sealed class DeleteDeliverymanHandler(
        IMapper mapper,
        ILogger<CreateDeliverymanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteDeliverymanCommand, Result>
    {
        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateDeliverymanHandler> _logger = logger;
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
