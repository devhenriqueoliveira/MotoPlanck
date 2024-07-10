using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Roles.Queries.GetAllRole
{
    internal sealed class GetAllRoleHandler(
        IMapper mapper,
        ILogger<GetAllRoleHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetAllRoleQuery, Result<IEnumerable<RoleResponse>>>
    {
        #region Fields

        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetAllRoleHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #endregion

        #region Handlers
        public async Task<Result<IEnumerable<RoleResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to get all roles");

            var roles = await _unitOfWork.Roles.GetAllAsync(cancellationToken);
            var response = _mapper.Map<IEnumerable<RoleResponse>>(roles.Value);

            return Result.Success(response);
        }

        #endregion
    }
}
