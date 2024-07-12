using MediatR;
using MotoPlanck.Application.Core.Roles.Commands.DeleteRole;
using MotoPlanck.Application.Core.Roles.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public sealed class DeleteRole : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("role/{id}", async (ISender sender, Guid id) =>
                await Result.Create(new DeleteRoleRequest() { Id = id }, Errors.UnProcessableRequest)
                    .Map(value => new DeleteRoleCommand(id))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest))
                    .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
