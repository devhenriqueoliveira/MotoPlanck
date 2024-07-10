using AutoMapper;
using Microsoft.Extensions.Logging;
using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Responses;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Deliverymans.Queries.GetDeliverymans
{
    internal class GetDeliverymansHandler(
        IMapper mapper,
        ILogger<GetDeliverymansHandler> logger,
        IUnitOfWork unitOfWork) : IQueryHandler<GetDeliverymansQuery, Result<IEnumerable<DeliverymanResponse>>>
    {
        #region Fields
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetDeliverymansHandler> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion

        public Task<Result<IEnumerable<DeliverymanResponse>>> Handle(GetDeliverymansQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
