using FluentValidation;
using MotoPlanck.Application.Abstractions.Common;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Motorcycles.Commands.CreateMotorcycle
{
    /// <summary>
    /// Represents the <see cref="CreateMotorcycleCommand"/> validator.
    /// </summary>
    public sealed class CreateMotorcycleValidator : AbstractValidator<CreateMotorcycleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotorcycleValidator(IUnitOfWork unitOfWork, IDateTime dateTime)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Year)
                .GreaterThan(0).WithMessage("Year must be greater than 0.")
                .ExclusiveBetween(1885, dateTime.UtcNow.Year).WithMessage($"Year must be between 1885 and {dateTime.UtcNow.Year}");

            RuleFor(command => command.Plate)
                .NotEmpty().WithMessage("Plate cannot be empty.")
                .NotNull().WithMessage("Plate cannot be null.")
                .MustAsync(BeUniquePlate).WithMessage("Plate must be unique.");

            RuleFor(command => command.Model)
                .NotEmpty().WithMessage("Model cannot be empty.")
                .NotNull().WithMessage("Model cannot be null.");
        }

        private async Task<bool> BeUniquePlate(string plate, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.Motorcycles.ExistsPlateAsync(plate, cancellationToken);
            return !exists.IsSuccess;
        }
    }
}
