using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.CreateRole
{
    /// <summary>
    /// Represents <see cref="CreateRoleCommand"/> handler.
    /// </summary>
    /// <param name="logger">The logs of <see cref="CreateRoleHandler"/></param>
    /// <param name="mapper">The mapper objects of <see cref="CreateRoleHandler"/></param>
    /// <param name="unitOfWork">The unit of work of repositories</param>
    internal sealed class CreateRoleHandler(
        ILogger<CreateRoleHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateRoleCommand, Result>
    {
        private readonly ILogger<CreateRoleHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the role creation process...");

            var entity = _mapper.Map<Role>(command);
            var response = await _unitOfWork.Roles.CreateAsync(entity!, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Role.CreateRoleOnDatabase);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Role created with success.");

            return Result.Success();
        }
    }
}
