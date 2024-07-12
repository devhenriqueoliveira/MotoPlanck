using MediatR;
using MotoPlanck.Application.Core.Plans.Queries.GetPlanById;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Plan
{
    public sealed class GetPlanById : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("plan/{id}", async (ISender sender, Guid id) =>
                await sender.Send(new GetPlanByIdQuery(id))).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
