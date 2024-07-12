using FluentValidation;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Roles.Commands.DeleteRole
{
    /// <summary>
    /// Represents the <see cref="DeleteRoleCommand" validator./>
    /// </summary>
    public sealed class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRoleValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Id)
               .NotNull().WithMessage("The identificator is not null.")
               .MustAsync(ExistsIdentificator).WithMessage("The role is not exists.");
        }

        private async Task<bool> ExistsIdentificator(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Roles.ExistsRoleAsync(id, cancellationToken);
        }
    }
}
