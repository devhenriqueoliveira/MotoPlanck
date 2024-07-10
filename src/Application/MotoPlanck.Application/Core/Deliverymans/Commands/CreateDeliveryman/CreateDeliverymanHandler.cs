using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman
{
    /// <summary>
    /// Represents the <see cref="CreateDeliverymanCommand"/> handler.
    /// </summary>
    /// <param name="mapper">The mapper of <see cref="CreateDeliverymanHandler"/>.</param>
    /// <param name="logger">The logger of <see cref="CreateDeliverymanHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories</param>
    internal sealed class CreateDeliverymanHandler(
        IMapper mapper,
        ILogger<CreateDeliverymanHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateDeliverymanCommand, Result>
    {
        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateDeliverymanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        #region Handlers
        public async Task<Result> Handle(CreateDeliverymanCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to create a deliveryman.");

            var entity = _mapper.Map<Deliveryman>(command);
            var response = await _unitOfWork.Deliverymans.CreateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Deliveryman.CreateDeliverymanOnDatabase);

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        #endregion
    }
}
