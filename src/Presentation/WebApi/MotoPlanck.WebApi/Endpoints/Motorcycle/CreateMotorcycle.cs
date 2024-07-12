using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Application.Core.Motorcycles.Contracts.Requests;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public sealed class CreateMotorcycle : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("motorcycle", async (
                ISender sender,
                CreateMotorcycleRequest request) =>
            {
                return await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new CreateMotorcycleCommand(
                    request.Year,
                    request.Model,
                    request.Plate))
                .Bind(command => sender.Send(command))
                .Match(Created, BadRequest);
            }).RequireAuthorization(SettingsConstants.ADMIN_POLICY);
        }
    }
}
