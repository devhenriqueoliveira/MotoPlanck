using MediatR;
using MotoPlanck.Application.Core.Authentications.Commands.LoginAuthentication;
using MotoPlanck.Application.Core.Authentications.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Authentication
{
    public sealed class LoginAuthentication : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("login", async (ISender sender, LoginRequest request) => 
            { 
                var response = await sender.Send(new LoginAuthenticationCommand(request.Login, request.Password));
                
                return Results.Ok(response);
            });
        }
    }
}
