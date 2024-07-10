using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents the <see cref="CreateUserCommand"/> handler.
    /// </summary>
    /// <param name="mapper">The mapper of <see cref="CreateUserHandler"/>.</param>
    /// <param name="logger">The logger of <see cref="CreateUserHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories.</param>
    internal sealed class CreateUserHandler(
        IMapper mapper,
        ILogger<CreateUserCommand> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Result>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateUserCommand> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting process to create a user");

            var entity = _mapper.Map<User>(command);
            var result = await _unitOfWork.Users.CreateAsync(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure(ValidationErros.User.CreateUserOnDatabase);

            await _unitOfWork.CommitAsync();
            
            _logger.LogInformation("Create user with success.");

            return Result.Success();
        }
    }
}
