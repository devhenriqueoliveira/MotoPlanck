using FluentValidation;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Roles.Commands.UpdateRole
{
    public sealed class UpdateRoleValidator: AbstractValidator<UpdateRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork; 
        public UpdateRoleValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
                .NotNull().WithMessage("Identificator cannot be null.")
                .MustAsync(ExistsIdentificator).WithMessage("The role is not exists");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(2, 30).WithMessage("Name must be between 2 and 30 characters.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Plate cannot be empty.")
                .Length(2, 200).WithMessage("Description must be between 2 and 200 characters.");
        }

        private async Task<bool> ExistsIdentificator(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Roles.ExistsRoleAsync(id, cancellationToken);
        }
    }
}
