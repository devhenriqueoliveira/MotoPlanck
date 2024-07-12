using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycleByPlate;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class GetMotorcycleByPlate : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("motorcycle/plate={plate}", async (ISender sender, string plate) => 
                await sender.Send(new GetMotorcycleByPlateQuery(plate)));
        }
    }
}
