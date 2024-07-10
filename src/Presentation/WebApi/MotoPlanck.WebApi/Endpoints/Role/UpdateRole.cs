using MediatR;
using MotoPlanck.Application.Core.Roles.Commands.UpdateRole;
using MotoPlanck.Application.Core.Roles.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public sealed class UpdateRole : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("role/{id}", async (ISender sender, Guid id, UpdateRoleRequest request) =>
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new UpdateRoleCommand(
                        id,
                        request.Name,
                        request.Description,
                        request.Active))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest));
            //RequireAuthorization("AdminPolicy")
        }
    }
}
