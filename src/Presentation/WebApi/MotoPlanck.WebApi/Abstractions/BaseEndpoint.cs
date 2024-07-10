using MotoPlanck.Domain.Primitives;
using MotoPlanck.WebApi.Contracts;

namespace MotoPlanck.WebApi.Abstractions
{
    public class BaseEndpoint
    {
        protected static IResult Ok() => Results.Ok();
        protected static IResult Created() => Results.Created();
        protected static IResult BadRequest(Error error) => Results.BadRequest(new ApiErrorResponse([error]));
        //protected static IResult BadRequest(IReadOnlyCollection<Error> errors) => Results.BadRequest(new ApiErrorResponse(errors));
    }
}
