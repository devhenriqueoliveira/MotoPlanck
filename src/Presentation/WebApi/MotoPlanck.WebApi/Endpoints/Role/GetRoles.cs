using MediatR;
using MotoPlanck.Application.Core.Roles.Queries.GetAllRole;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Role
{
    public sealed class GetRoles : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("role", async (ISender sender) =>
               await sender.Send(new GetAllRoleQuery()))
                .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
