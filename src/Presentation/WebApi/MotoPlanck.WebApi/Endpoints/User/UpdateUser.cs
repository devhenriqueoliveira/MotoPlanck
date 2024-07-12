using MediatR;
using MotoPlanck.Application.Core.Users.Commands.UpdateUser;
using MotoPlanck.Application.Core.Users.Contracts.Requests;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.User
{
    /// <summary>
    /// The endpoint to update a user.
    /// </summary>
    public sealed class UpdateUser : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("user/{id}", async(ISender sender, Guid id, UpdateUserRequest request) => 
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new UpdateUserCommand(
                        id,
                        request.FirstName,
                        request.LastName,
                        request.Login,
                        request.Password,
                        request.Email,
                        request.BirthDate,
                        request.RoleId))
                    .Bind(command => sender.Send(command))
                    .Match(NoContent, BadRequest))
                    .RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
