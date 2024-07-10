using FluentValidation;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.UpdateMotorcycle
{
    /// <summary>
    /// Represents the <see cref="UpdateMotorcycleCommand"/> validator.
    /// </summary>
    public sealed class UpdateMotorcycleValidator : AbstractValidator<UpdateMotorcycleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMotorcycleValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Plate)
                .NotEmpty().WithMessage("Plate cannot be empty.")
                .NotNull().WithMessage("Plate cannot be null.")
                .MustAsync(BeUniquePlate).WithMessage("Plate already registered.");
        }

        private async Task<bool> BeUniquePlate(string plate, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.Motorcycles.ExistsPlateAsync(plate, cancellationToken);
            return !exists.IsSuccess;
        }
    }
}
