using MediatR;
using MotoPlanck.Application.Core.Plans.Commands.UpdatePlan;
using MotoPlanck.Application.Core.Plans.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Plan
{
    /// <summary>
    /// Represents the endpoint to update a plan.
    /// </summary>
    public sealed class UpdatePlan : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("plan/{id}", async (ISender sender, Guid id, UpdatePlanRequest request) =>
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new UpdatePlanCommand(
                        id,
                        request.Day,
                        request.Amount,
                        request.RatePercentage))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest)).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
