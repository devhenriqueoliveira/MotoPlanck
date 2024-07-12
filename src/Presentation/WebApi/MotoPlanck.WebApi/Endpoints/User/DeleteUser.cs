using MediatR;
using MotoPlanck.Application.Core.Users.Commands.DeleteUser;
using MotoPlanck.Application.Core.Users.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.User
{
    /// <summary>
    /// Represents the endpoint for deleting a user.
    /// </summary>
    public sealed class DeleteUser : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("user/{id}", async (ISender sender, Guid id) =>
            {
                var request = new DeleteUserRequest() { Id = id };

                return await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new DeleteUserCommand(id))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest);

            }).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
