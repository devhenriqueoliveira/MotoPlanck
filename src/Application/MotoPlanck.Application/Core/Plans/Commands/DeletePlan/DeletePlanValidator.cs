using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Plans.Commands.DeletePlan
{
    public sealed class DeletePlanValidator : AbstractValidator<DeletePlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlanValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
              .NotNull().WithErrorCode(ValidationErros.Plan.IdNull.Code).WithMessage(ValidationErros.Plan.IdNull.Message)
              .MustAsync(ExistsPlanById).WithErrorCode(ValidationErros.Plan.PlanNoExists.Code).WithMessage(ValidationErros.Plan.PlanNoExists.Message);
        }

        private async Task<bool> ExistsPlanById(Guid guid, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Plans.ExistsPlanById(guid, cancellationToken);
        }
    }
}
