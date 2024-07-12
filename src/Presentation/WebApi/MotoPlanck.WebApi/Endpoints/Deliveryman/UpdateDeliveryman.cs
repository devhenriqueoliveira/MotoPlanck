using MediatR;
using MotoPlanck.Application.Core.Deliverymans.Commands.UpdateDeliveryman;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Deliveryman
{
    public class UpdateDeliveryman : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("deliveryman/{id}", async (ISender sender, Guid id, UpdateDeliverymanRequest request) =>
                await Result.Create(request, Errors.UnProcessableRequest)
                    .Map(value => new UpdateDeliverymanCommand(
                        id,
                        request.Cnpj,
                        request.Cnh,
                        request.TypeCnh,
                        request.PictureCnhId,
                        request.UserId))
                    .Bind(command => sender.Send(command))
                    .Match(Ok, BadRequest));//.RequireAuthorization("AdminPolicy");
        }
    }
}
