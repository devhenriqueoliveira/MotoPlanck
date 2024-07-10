using MotoPlanck.WebApi.Abstractions;

namespace MotoPlanck.WebApi.Endpoints.Motorcycle
{
    public class GetByIdMotorcycle : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("motorcycle/{id}", (int id) => "Get endpoint");
        }
    }
}
