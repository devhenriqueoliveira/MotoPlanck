namespace MotoPlanck.Domain.Primitives.Result
{
    public class Result //TODO
    {
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        protected Result(IEnumerable<Error> errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public IEnumerable<Error> Errors { get; }
        public static Result Success() => new(true, Error.None);
        public static async Task<Result> SuccessAsync() => await Task.FromResult<Result>(new(true, Error.None));
        public static Result<TValue> Success<TValue>(TValue value) 
            => new(value, true, Error.None);
        public static Result<TValue> Create<TValue>(TValue value, Error error)
            where TValue : class
            => value is null ? Failure<TValue>(error) : Success(value);
        public static Result Failure(Error error) => new(false, error);

        public static async Task<Result> FailureAsync(Error error) => await Task.FromResult<Result>(new(false, error));
        public static async Task<Result> FailureAsync(IEnumerable<Error> errors) => await Task.FromResult(new Result(errors));

        public static Result<TValue> Failure<TValue>(Error error) 
            => new(default!, false, error);

        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Success();
        }
    }
}
