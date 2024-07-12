using MediatR;
using MotoPlanck.Application.Core.Plans.Commands.DeletePlan;
using MotoPlanck.Application.Core.Plans.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Plan
{
    public sealed class DeletePlan : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("plan/{id}", async(ISender sender, Guid id) => 
                await Result.Create(new DeletePlanRequest(), Errors.UnProcessableRequest)
                .Map(value => new DeletePlanCommand(id))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest)).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
