using MediatR;
using MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Deliveryman
{
    public sealed class CreateDeliveryman : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("deliveryman", async (ISender sender, CreateDeliverymanRequest request) =>
            {
                return await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new CreateDeliverymanCommand(
                    request.Cnpj,
                    request.Cnh,
                    request.TypeCnh,
                    request.PictureCnhId,
                    request.UserId))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest);
            });//.RequireAuthorization("AdminPolicy");
        }
    }
}
