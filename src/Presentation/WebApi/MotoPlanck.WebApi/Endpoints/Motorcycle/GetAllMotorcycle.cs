using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Queries.GetAllMotorcycle;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class GetAllMotorcycle : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("motorcycle", async (
                ISender sender) =>
            {
                return await sender.Send(new GetAllMotorcycleQuery());
            });
        }
    }
}
