using MediatR;
using MotoPlanck.Application.Core.Roles.Commands.CreateRole;
using MotoPlanck.Application.Core.Roles.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public class CreateRole : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("role", async (ISender sender, CreateRoleRequest request) => 
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new CreateRoleCommand(
                        request.Name,
                        request.Description,
                        request.Active))
                    .Bind(command => sender.Send(command))
                    .Match(Created, BadRequest));
                    //RequireAuthorization("AdminPolicy")
        }
    }
}
