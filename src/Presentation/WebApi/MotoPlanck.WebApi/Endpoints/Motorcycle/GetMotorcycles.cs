using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Queries.GetMotorcycles;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class GetMotorcycles : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("motorcycle", async (ISender sender) =>
                 await sender.Send(new GetMotorcyclesQuery()))
                    .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
