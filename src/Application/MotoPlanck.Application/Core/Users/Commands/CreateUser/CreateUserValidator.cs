using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents the <see cref="CreateUserCommand"/> validator.
    /// </summary>
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.FirstName)
                .NotEmpty().WithErrorCode(ValidationErros.User.FirstNameEmpty.Code).WithMessage(ValidationErros.User.FirstNameEmpty.Message)
                .Length(2, 30).WithErrorCode(ValidationErros.User.FirstNameLength.Code).WithMessage(ValidationErros.User.FirstNameLength.Message);

            RuleFor(command => command.LastName)
                .NotEmpty().WithErrorCode(ValidationErros.User.LastNameEmpty.Code).WithMessage(ValidationErros.User.LastNameEmpty.Message)
                .Length(2, 30).WithErrorCode(ValidationErros.User.LastNameLength.Code).WithMessage(ValidationErros.User.LastNameLength.Message);

            RuleFor(command => command.Login)
                .NotEmpty().WithErrorCode(ValidationErros.User.LoginEmpty.Code).WithMessage(ValidationErros.User.LoginEmpty.Message)
                .Length(2, 18).WithErrorCode(ValidationErros.User.LoginLength.Code).WithMessage(ValidationErros.User.LoginLength.Message)
                .MustAsync(ExistsLoginAsync).WithErrorCode(ValidationErros.User.LoginExists.Code).WithMessage(ValidationErros.User.LoginExists.Message);

            RuleFor(command => command.Password)
                .NotEmpty().WithErrorCode(ValidationErros.User.PasswordEmpty.Code).WithMessage(ValidationErros.User.PasswordEmpty.Message)
                .Length(2, 30).WithErrorCode(ValidationErros.User.PasswordLength.Code).WithMessage(ValidationErros.User.PasswordLength.Message);

            RuleFor(command => command.Email)
                .NotEmpty().WithErrorCode(ValidationErros.User.EmailEmpty.Code).WithMessage(ValidationErros.User.EmailEmpty.Message)
                .EmailAddress().WithErrorCode(ValidationErros.User.EmailIsNotValid.Code).WithMessage(ValidationErros.User.EmailIsNotValid.Message)
                .MustAsync(ExistsEmailAsync).WithErrorCode(ValidationErros.User.EmailExists.Code).WithMessage(ValidationErros.User.EmailExists.Message);

            RuleFor(command => command.BirthDate)
                .NotEmpty().WithErrorCode(ValidationErros.User.BirthDateNull.Code).WithMessage(ValidationErros.User.BirthDateNull.Message)
                .MustAsync(BeAValidAge).WithErrorCode(ValidationErros.User.BirthDateIsNotValid.Code).WithMessage(ValidationErros.User.BirthDateIsNotValid.Message);

            RuleFor(command => command.RoleId)
                .NotNull().WithErrorCode(ValidationErros.User.RoleNull.Code).WithMessage(ValidationErros.User.RoleNull.Message)
                .MustAsync(ExistsRole).WithErrorCode(ValidationErros.User.NoExistsRole.Code).WithMessage(ValidationErros.User.NoExistsRole.Code);
        }

        private async Task<bool> BeAValidAge(DateTime birthDate, CancellationToken token)
        {
            int currentYear = DateTime.Now.Year;
            int birthYear = birthDate.Year;
            var isValidAge = (currentYear - birthYear) >= 18;

            return await Task.FromResult(isValidAge);
        }

        private async Task<bool> ExistsLoginAsync(string login, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Users.ExistsLoginAsync(login, cancellationToken);
            return !response;
        }

        private async Task<bool> ExistsEmailAsync(string email, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Users.ExistsEmailAsync(email, cancellationToken);
            return !response;
        }

        private async Task<bool> ExistsRole(Guid id, CancellationToken cancellationToken) =>
            await _unitOfWork.Roles.ExistsRoleAsync(id, cancellationToken);
    }
}
