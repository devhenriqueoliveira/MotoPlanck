using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Users.Commands.DeleteUser
{
    /// <summary>
    /// Represents the <see cref="DeleteUserCommand"/> validator.
    /// </summary>
    public sealed class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
                .NotNull().WithErrorCode(ValidationErros.User.IdNull.Code).WithMessage(ValidationErros.User.FirstNameEmpty.Message)
                .MustAsync(ExistsUser).WithErrorCode(ValidationErros.User.UserNoExists.Code).WithMessage(ValidationErros.User.UserNoExists.Message);
        }

        /// <summary>
        /// Method to check if user exists.
        /// </summary>
        /// <param name="id">The identificator of user.</param>
        /// <param name="cancellationToken">The token for operations that must be canceled</param>
        /// <returns>Returns a boolean</returns>
        private async Task<bool> ExistsUser(Guid id, CancellationToken cancellationToken) =>
            await _unitOfWork.Users.ExistsUserAsync(id, cancellationToken);
    }
}
