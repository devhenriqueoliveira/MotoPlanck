using MediatR;
using MotoPlanck.Application.Core.Plans.Queries.GetPlans;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Plan
{
    public sealed class GetPlans : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("plan", async (ISender sender) => 
                await sender.Send(new GetPlansQuery())).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
