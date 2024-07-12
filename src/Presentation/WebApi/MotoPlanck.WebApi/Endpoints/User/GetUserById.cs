using MediatR;
using MotoPlanck.Application.Core.Users.Queries.GetUserById;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.User
{
    public sealed class GetUserById : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("user/{id}", async (ISender sender, Guid id) =>
                await sender.Send(new GetUserByIdQuery(id)))
                    .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
