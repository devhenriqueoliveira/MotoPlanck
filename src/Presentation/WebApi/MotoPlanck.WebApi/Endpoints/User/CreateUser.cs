using MediatR;
using MotoPlanck.Application.Core.Users.Commands.CreateUser;
using MotoPlanck.Application.Core.Users.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.User
{
    public class CreateUser : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("user", async (ISender sender, CreateUserRequest request) =>
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new CreateUserCommand(
                        request.FirstName,
                        request.LastName,
                        request.Login,
                        request.Password,
                        request.Email,
                        request.BirthDate,
                        request.RoleId))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest));
            //RequireAuthorization("AdminPolicy")
        }
    }
}
