using MediatR;
using MotoPlanck.Application.Core.Users.Queries.GetAllUser;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.User
{
    public class GetAllUser : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("user", async (ISender sender) =>
            {
                var users = await sender.Send(new GetAllUserQuery());

                return Result.Success(users.Value);
            });
            //RequireAuthorization("AdminPolicy")
        }
    }
}
