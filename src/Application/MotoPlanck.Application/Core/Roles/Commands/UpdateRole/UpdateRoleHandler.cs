using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.UpdateRole
{
    /// <summary>
    /// Represents a <see cref="UpdateRoleCommand"/> handler.
    /// </summary>
    /// <param name="mapper">The mapper of <see cref="UpdateRoleHandler"/></param>
    /// <param name="logger">The logger of <see cref="UpdateRoleHandler"/></param>
    /// <param name="unitOfWork">The unit of work of repositories</param>
    internal sealed class UpdateRoleHandler(
        IMapper mapper,
        ILogger<UpdateRoleHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<UpdateRoleCommand, Result>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UpdateRoleHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the role updation process...");

            var entity = _mapper.Map<Role>(command);
            var response = await _unitOfWork.Roles.UpdateAsync(entity, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Role.UpdateRoleOnDatabase);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Update completed successfully");

            return Result.Success();
        }
    }
}
