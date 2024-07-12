using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.UpdateDeliveryman
{
    internal sealed class UpdateDeliverymanHandler(
        IMapper mapper,
        ILogger<UpdateDeliverymanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<UpdateDeliverymanCommand, Result>
    {
        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UpdateDeliverymanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        public async Task<Result> Handle(UpdateDeliverymanCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to update a deliveryman.");

            var entity = _mapper.Map<Deliveryman>(command);
            var response = await _unitOfWork.Deliverymans.UpdateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Deliveryman.UpdateDeliverymanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
