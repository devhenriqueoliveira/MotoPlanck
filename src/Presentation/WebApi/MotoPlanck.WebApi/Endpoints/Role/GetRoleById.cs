using MediatR;
using MotoPlanck.Application.Core.Roles.Queries.GetByIdRole;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public sealed class GetRoleById : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("role/{id}", async (ISender sender, Guid id) =>
               await sender.Send(new GetRoleByIdQuery(id)))
                .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
