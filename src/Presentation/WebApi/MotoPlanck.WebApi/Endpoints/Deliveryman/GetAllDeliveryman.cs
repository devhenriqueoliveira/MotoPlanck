using MediatR;
using MotoPlanck.Application.Core.Deliverymans.Queries.GetAllDeliveryman;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Deliveryman
{
    public sealed class GetAllDeliveryman : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("deliveryman", async (ISender sender) =>
                   await sender.Send(new GetDeliverymansQuery()));
        }
    }
}
