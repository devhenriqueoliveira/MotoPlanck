using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Plans.Commands.UpdatePlan
{
    /// <summary>
    /// Represents the <see cref="UpdatePlanCommand"/> validator.
    /// </summary>
    public sealed class UpdatePlanValidator : AbstractValidator<UpdatePlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePlanValidator(IUnitOfWork unitOfWork) //TODO Colocar uma validação para não permitir criar planos com os mesmos dias já existentes (Validar se faz sentido, viãndo que será uma tabela "Constante")
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
              .NotNull().WithErrorCode(ValidationErros.Plan.IdNull.Code).WithMessage(ValidationErros.Plan.IdNull.Message)
              .MustAsync(ExistsPlanById).WithErrorCode(ValidationErros.Plan.PlanNoExists.Code).WithMessage(ValidationErros.Plan.PlanNoExists.Message);

            RuleFor(command => command.Day)
              .NotNull().WithErrorCode(ValidationErros.Plan.DayNull.Code).WithMessage(ValidationErros.Plan.DayNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.DayGreaterThanZero.Code).WithMessage(ValidationErros.Plan.DayGreaterThanZero.Message);

            RuleFor(command => command.Amount)
              .NotNull().WithErrorCode(ValidationErros.Plan.AmountNull.Code).WithMessage(ValidationErros.Plan.AmountNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.AmountGreaterThanZero.Code).WithMessage(ValidationErros.Plan.AmountGreaterThanZero.Message);

            RuleFor(command => command.RatePercentage)
              .NotNull().WithErrorCode(ValidationErros.Plan.RatePercentageNull.Code).WithMessage(ValidationErros.Plan.RatePercentageNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.RatePercentageGreaterThanZero.Code).WithMessage(ValidationErros.Plan.RatePercentageGreaterThanZero.Message);

        }

        private async Task<bool> ExistsPlanById(Guid guid, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Plans.ExistsPlanById(guid, cancellationToken);
        }
    }
}
