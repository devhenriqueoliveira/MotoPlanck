using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Plans.Commands.CreatePlan
{
    /// <summary>
    /// Represents the <see cref="CreatePlanCommand"/> validator.
    /// </summary>
    public sealed class CreatePlanValidator : AbstractValidator<CreatePlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePlanValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Day)
              .NotNull().WithErrorCode(ValidationErros.Plan.DayNull.Code).WithMessage(ValidationErros.Plan.DayNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.DayGreaterThanZero.Code).WithMessage(ValidationErros.Plan.DayGreaterThanZero.Code);

            RuleFor(command => command.Amount)
              .NotNull().WithErrorCode(ValidationErros.Plan.AmountNull.Code).WithMessage(ValidationErros.Plan.AmountNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.AmountGreaterThanZero.Code).WithMessage(ValidationErros.Plan.AmountGreaterThanZero.Code);

            RuleFor(command => command.RatePercentage)
              .NotNull().WithErrorCode(ValidationErros.Plan.RatePercentageNull.Code).WithMessage(ValidationErros.Plan.RatePercentageNull.Message)
              .GreaterThan(0).WithErrorCode(ValidationErros.Plan.RatePercentageGreaterThanZero.Code).WithMessage(ValidationErros.Plan.RatePercentageGreaterThanZero.Code);
        }
    }
}
