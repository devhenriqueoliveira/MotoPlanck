using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Responses;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Queries.GetDeliverymanById
{
    internal sealed class GetDeliverymanByIdHandler(
        IMapper mapper,
        ILogger<CreateDeliverymanHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetDeliverymanByIdQuery, Result<DeliverymanResponse>>
    {
        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateDeliverymanHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        public Task<Result<DeliverymanResponse>> Handle(GetDeliverymanByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
