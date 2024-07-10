using FluentValidation;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman
{
    /// <summary>
    /// Represents the <see cref="CreateDeliverymanCommand"/> validator.
    /// </summary>
    public sealed class CreateDeliverymanValidator : AbstractValidator<CreateDeliverymanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDeliverymanValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
