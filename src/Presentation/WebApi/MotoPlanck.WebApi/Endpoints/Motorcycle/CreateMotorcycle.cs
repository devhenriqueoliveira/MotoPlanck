using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoPlanck.Application.Core.Motorcycles.Contracts;
using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class CreateMotorcycle : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("motorcycle", async (
                ISender sender,
                [FromBody] CreateMotorcycleRequest request) =>
            {
                return await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new CreateMotorcycleCommand(
                    request.Year,
                    request.Model,
                    request.Plate))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest);
            }).RequireAuthorization("AdminPolicy");
        }
    }
}
