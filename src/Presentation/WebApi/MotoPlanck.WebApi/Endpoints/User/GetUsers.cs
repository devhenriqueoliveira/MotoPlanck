using MediatR;
using MotoPlanck.Application.Core.Users.Queries.GetUsers;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.User
{
    public sealed class GetUsers : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("user", async (ISender sender) =>
                await sender.Send(new GetUsersQuery()))
                    .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
