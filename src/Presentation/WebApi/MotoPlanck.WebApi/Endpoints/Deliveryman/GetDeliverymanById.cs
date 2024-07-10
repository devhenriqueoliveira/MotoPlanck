using MediatR;
using MotoPlanck.Application.Core.Deliverymans.Queries.GetDeliverymanById;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Deliveryman
{
    public class GetDeliverymanById : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("deliveryman/{id}", async (ISender sender, Guid id) =>
                 await sender.Send(new GetDeliverymanByIdQuery(id)));
        }
    }
}
