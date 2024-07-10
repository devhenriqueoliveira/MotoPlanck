using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Commands.DeleteRole
{
    /// <summary>
    /// Represents the <see cref="DeleteRoleCommand"/> handler.
    /// </summary>
    /// <param name="mapper">The mapper of <see cref="DeleteRoleCommand"/>.</param>
    /// <param name="logger">The role of <see cref="DeleteRoleCommand"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories.</param>
    internal sealed class DeleteRoleHandler(
        IMapper mapper,
        ILogger<DeleteRoleHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteRoleCommand, Result>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<DeleteRoleHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion

        #region Handlers
        public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process of delete role.");

            var response = await _unitOfWork.Roles.DeleteAsync(request.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure(ValidationErros.Role.DeleteRoleOnDatabase);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Role deleted with success.");

            return Result.Success();
        }

        #endregion
    }
}
