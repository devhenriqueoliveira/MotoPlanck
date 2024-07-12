using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserHandler(
        ILogger<UpdateUserHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand, Result>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<UpdateUserHandler> _logger = logger;

        #endregion

        #region Handlers
        public async Task<Result> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to update a user.");

            var entity = await command.ToEntityAsync(_unitOfWork.Roles, cancellationToken);

            if (entity.IsFailure)
                return Result.Failure(entity.Error);

            var response = await _unitOfWork.Users.UpdateAsync(entity.Value, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Operation realized with success.");

            return Result.Success();
        }

        #endregion
    }
}
