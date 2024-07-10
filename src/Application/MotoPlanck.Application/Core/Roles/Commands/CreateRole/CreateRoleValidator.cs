using FluentValidation;

namespace MotoPlanck.Application.Core.Roles.Commands.CreateRole
{
    /// <summary>
    /// Represents the <see cref="CreateRoleCommand"/> validator.
    /// </summary>
    public sealed class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(2, 30).WithMessage("Name must be between 2 and 30 characters.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Plate cannot be empty.")
                .Length(2, 200).WithMessage("Description must be between 2 and 200 characters.");
        }
    }
}
