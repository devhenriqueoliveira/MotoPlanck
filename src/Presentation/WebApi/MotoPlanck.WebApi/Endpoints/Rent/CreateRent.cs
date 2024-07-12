using MediatR;
using MotoPlanck.Application.Core.Rentals.Commands.CreateRent;
using MotoPlanck.Application.Core.Rentals.Contracts.Requests;
using MotoPlanck.Domain.Primitives.Result;
using MotoPlanck.WebApi.Abstractions;
using MotoPlanck.WebApi.Constants;

namespace MotoPlanck.WebApi.Endpoints.Rent
{
    public class CreateRent : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("rent", async (ISender sender, CreateRentRequest request) => 
                await Result.Create(request, Errors.UnProcessableRequest)
                .Map(value => new CreateRentCommand(
                    request.InitialDate,
                    request.FinalDate,
                    request.ForecastDate,
                    request.DeliverymanId,
                    request.PlanId,
                    request.MotorcycleId))
                .Bind(command => sender.Send(command))
                .Match(Created, BadRequest));
        }
    }
}
