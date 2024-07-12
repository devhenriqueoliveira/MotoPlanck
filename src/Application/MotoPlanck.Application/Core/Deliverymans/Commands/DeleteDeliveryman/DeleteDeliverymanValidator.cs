using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.DeleteDeliveryman
{
    public sealed class DeleteDeliverymanValidator : AbstractValidator<DeleteDeliverymanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDeliverymanValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
                .NotNull().WithErrorCode(ValidationErros.Deliveryman.IdNull.Code).WithMessage(ValidationErros.Deliveryman.IdNull.Message)
                .MustAsync(ExistsDeliveryman).WithErrorCode(ValidationErros.Deliveryman.ExistsDeliveryman.Code).WithMessage(ValidationErros.Deliveryman.ExistsDeliveryman.Message);
        }

        private async Task<bool> ExistsDeliveryman(Guid id, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Deliverymans.ExistsDeliverymanAsync(id, cancellationToken);
            return response;
        }
    }
}
