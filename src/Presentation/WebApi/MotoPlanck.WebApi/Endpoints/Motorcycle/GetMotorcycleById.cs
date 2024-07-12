using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleById;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class GetMotorcycleById : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("motorcycle/id={id}", async (ISender sender, Guid id) => 
                await sender.Send(new GetMotorcycleByIdQuery(id)));
        }
    }
}
