using FluentValidation;

namespace MotoPlanck.Application.Core.Users.Commands.CreateUser
{
    /// <summary>
    /// Represents the <see cref="CreateUserCommand"/> validator.
    /// </summary>
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(2, 30).WithMessage("First name must be between 2 and 30 characters.");

            RuleFor(command => command.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 30).WithMessage("Last name must be between 2 and 30 characters.");

            RuleFor(command => command.Login)
                .NotEmpty().WithMessage("Login is required.")
                .Length(2, 16).WithMessage("Login name must be between 2 and 16 characters."); //TODO Colocar Validação, caso já exista o login cadastrado

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format."); //TODO Colocar Validação, caso já exista o email cadastrado

            RuleFor(user => user.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .Must(BeAValidAge).WithMessage("You must be at least 18 years old.");

        }

        private bool BeAValidAge(DateTime birthDate)
        {
            int currentYear = DateTime.Now.Year;
            int birthYear = birthDate.Year;
            return (currentYear - birthYear) >= 18;
        }
    }
}
