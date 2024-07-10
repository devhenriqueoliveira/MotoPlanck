using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Users.Queries.GetAllUser
{
    internal sealed class GetAllUserHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<GetAllUserHandler> _logger) : IQueryHandler<GetAllUserQuery, Result<IEnumerable<UserResponse>>>
    {
        private readonly ILogger<GetAllUserHandler> _logger = _logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando...");

            var users = await _unitOfWork.Users.GetAllAsync(cancellationToken);

            var response = _mapper.Map<IEnumerable<UserResponse>>(users.Value);

            _logger.LogInformation("Selecionado com sucesso...");

            return Result.Success(response);
        }
    }
}
