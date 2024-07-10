using MediatR;
using MotoPlanck.Application.Core.Motorcycles.Commands.DeleteMotorcycle;
using MotoPlanck.Application.Core.Motorcycles.Contracts;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class DeleteMotorcycle : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("motorcycle/{id}", async (
                ISender sender,
                Guid id) =>
            {
                return await Result.Create(new DeleteMotorcycleRequest(id), Errors.UnProcessableRequest)
                .Map(value => new DeleteMotorcycleCommand(id))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest);
            });
        }
    }
}
