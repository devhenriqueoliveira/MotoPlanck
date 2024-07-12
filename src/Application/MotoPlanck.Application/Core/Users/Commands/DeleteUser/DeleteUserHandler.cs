using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.DeleteUser
{
    /// <summary>
    /// Represents the <see cref="DeleteUserCommand"/> handler.
    /// </summary>
    /// <param name="logger">The looger of <see cref="DeleteUserHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories.</param>
    internal sealed class DeleteUserHandler(
        ILogger<DeleteUserHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand, Result>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<DeleteUserHandler> _logger = logger;

        #endregion

        #region Handlers
        public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to delete a user.");

            var response = await _unitOfWork.Users.DeleteAsync(command.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Operation realized with success.");

            return Result.Success();
        }

        #endregion
    }
}
