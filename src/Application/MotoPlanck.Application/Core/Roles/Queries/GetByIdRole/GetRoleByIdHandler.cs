using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Queries.GetByIdRole
{
    /// <summary>
    /// Represents the <see cref="GetRoleByIdQuery" /> handler.
    /// </summary>
    /// <param name="mapper">The mapper of <see cref="GetRoleByIdHandler"/>.</param>
    /// <param name="logger">The logger of <see cref="GetRoleByIdHandler"/>.</param>
    /// <param name="unitOfWork">The unit of work of repositories.</param>
    internal sealed class GetRoleByIdHandler(
        IMapper mapper,
        ILogger<GetRoleByIdHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetRoleByIdQuery, Result<RoleResponse>>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetRoleByIdHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion

        #region Handlers
        public async Task<Result<RoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting process to get role by id.");

            var role = await _unitOfWork.Roles.GetByIdAsync(request.Id, cancellationToken);
            var response = _mapper.Map<RoleResponse>(role.Value);

            return Result.Success(response);
        }

        #endregion
    }
}
