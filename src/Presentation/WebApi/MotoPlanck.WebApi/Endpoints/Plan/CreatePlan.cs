using MediatR;
using MotoPlanck.Application.Core.Plans.Commands.CreatePlan;
using MotoPlanck.Application.Core.Plans.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Plan
{
    public sealed class CreatePlan : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("plan", async (ISender sender, CreatePlanRequest request) => 
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new CreatePlanCommand(
                        request.Day,
                        request.Amount,
                        request.RatePercentage))
                    .Bind(command => sender.Send(command))
                    .Match(Created, BadRequest)).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
