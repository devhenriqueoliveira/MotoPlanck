using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetUserByIdHandler> _logger) : IQueryHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly ILogger<GetUserByIdHandler> _logger = _logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting the process to get user by id.");

            var response = await _unitOfWork.Users.GetByIdAsync(request.Id, cancellationToken);

            if (response.IsFailure)
                return Result.Failure<UserResponse>(response.Error);

            _logger.LogInformation("Operation realized with success.");

            return Result.Success(response.Value.ToUserResponse());
        }
    }
}
