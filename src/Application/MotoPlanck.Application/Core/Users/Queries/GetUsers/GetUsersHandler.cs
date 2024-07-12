using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetUsers
{
    internal sealed class GetUsersHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetUsersHandler> _logger) : IQueryHandler<GetUsersQuery, Result<IEnumerable<UserResponse>>>
    {
        private readonly ILogger<GetUsersHandler> _logger = _logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to get users.");

            var response = await _unitOfWork.Users.GetAllAsync(cancellationToken);

            if(response.IsFailure)
                return Result.Failure<IEnumerable<UserResponse>>(response.Error);

            _logger.LogInformation("Operation realized with success.");

            return Result.Success(response.Value.ToUserResponse());
        }
    }
}
