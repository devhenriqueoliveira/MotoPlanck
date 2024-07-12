using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Authentications.Contracts.Responses;
using MotoPlanck.Application.Mappings;
using MotoPlanck.Application.Services.JwtBearer;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Authentications.Commands.LoginAuthentication
{
    internal sealed class LoginAuthenticationHandler(
        IJwtBearerService<LoginAuthenticationResponse> jwtBearerService,
        ILogger<LoginAuthenticationHandler> logger,
        IUnitOfWork unitOfWork) : ICommandHandler<LoginAuthenticationCommand, Result>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<LoginAuthenticationHandler> _logger = logger;
        private readonly IJwtBearerService<LoginAuthenticationResponse> _jwtBearerService = jwtBearerService;
        #endregion
        public async Task<Result> Handle(LoginAuthenticationCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting process to authenticated user.");

            var user = await _unitOfWork.Users.GetUserByloginAsync(command.Login, cancellationToken);

            if (user.IsFailure)
                return Result.Failure(user.Error);

            if (!user.Value.VerifyPassword(command.Password))
                return Result.Failure(ValidationErros.User.PasswordInvalid);

            var loginAuthenticationResponse = user.Value.ToLoginAuthenticationResponse();
            var token = await _jwtBearerService.GenerateTokenAsync(loginAuthenticationResponse, cancellationToken);

            loginAuthenticationResponse.Token = token;

            _logger.LogInformation("Operation realized with success.");

            return Result.Success(loginAuthenticationResponse);
        }
    }
}
