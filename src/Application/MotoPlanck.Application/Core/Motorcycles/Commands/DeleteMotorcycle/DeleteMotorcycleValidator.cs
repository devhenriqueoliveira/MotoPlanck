using FluentValidation;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.DeleteMotorcycle
{
    /// <summary>
    /// Represents the <see cref="DeleteMotorcycleCommand"/> validator.
    /// </summary>
    public sealed class DeleteMotorcycleValidator : AbstractValidator<DeleteMotorcycleCommand>
    {
        public DeleteMotorcycleValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Identificator cannot be empty.")
                .NotNull().WithMessage("Identificator cannot be null.");
        }
    }
}
