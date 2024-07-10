using MediatR;
using MotoPlanck.Application.Core.Roles.Queries.GetByIdRole;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public class GetRoleById : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("role/{id}", async (ISender sender, Guid id) =>
               await sender.Send(new GetRoleByIdQuery(id)));
            //RequireAuthorization("AdminPolicy")
        }
    }
}
