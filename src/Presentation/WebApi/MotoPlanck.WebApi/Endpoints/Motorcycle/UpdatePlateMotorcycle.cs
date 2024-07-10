using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Commands.UpdateMotorcycle;
using MotoPlanck.Application.Core.Motorcycles.Contracts;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class UpdatePlateMotorcycle : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("motorcycle/{id}", async (
                ISender sender,
                Guid id,
                UpdatePlateMotorcycleRequest request) =>
            {
                return await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new UpdateMotorcycleCommand(id, request.Plate))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest);
            });
        }
    }
}
