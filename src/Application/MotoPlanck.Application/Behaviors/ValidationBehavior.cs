using FluentValidation;
using MediatR;
using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Behaviors
{
    /// <summary>
    /// Represents the validation behavior middleware.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest,TResponse}"/> class.
    /// </remarks>
    /// <param name="validators">The validator for the current request type.</param>
    internal sealed class ValidationBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        /// <inheritdoc />
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.ValidateAsync(context))
                .SelectMany(result => result.Result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var errors = failures.Select(value => new Error(value.ErrorCode, value.ErrorMessage));
                var result = Result.Failure(errors.First()) as TResponse;
                return result!;
            }

            return await next();
        }
    }
}
