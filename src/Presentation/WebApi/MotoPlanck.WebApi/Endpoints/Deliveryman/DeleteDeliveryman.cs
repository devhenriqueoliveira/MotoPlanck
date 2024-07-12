using MediatR;
using MotoPlanck.Application.Core.Deliverymans.Commands.DeleteDeliveryman;
using MotoPlanck.Application.Core.Deliverymans.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Deliveryman
{
    public sealed class DeleteDeliveryman : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("deliveryman/{id}", async (ISender sender, Guid id) =>
            {
                var request = new DeleteDeliverymanRequest() { Id = id };

                return await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new DeleteDeliverymanCommand(request.Id))
                .Bind(command => sender.Send(command))
                .Match(Ok, BadRequest);
            });//.RequireAuthorization("AdminPolicy");
        }
    }
}
