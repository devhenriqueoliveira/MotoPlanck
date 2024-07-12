using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.Application.Mappings;

namespace MotoPlanck.Application.Core.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents the <see cref="CreateUserCommand"/> handler.
    /// </summary>
    /// <param name="logger">The logger of <see cref="CreateUserHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories.</param>
    internal sealed class CreateUserHandler(
        ILogger<CreateUserCommand> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Result>
    {
        private readonly ILogger<CreateUserCommand> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting process to create a user.");

            var entity = await command.ToEntityAsync(_unitOfWork.Roles, cancellationToken);

            if (entity.IsFailure)
                return Result.Failure(entity.Error);

            var response = await _unitOfWork.Users.CreateAsync(entity.Value, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(response.Error);

            await _unitOfWork.CommitAsync();
            
            _logger.LogInformation("Operation realized with success.");

            return Result.Success();
        }
    }
}
