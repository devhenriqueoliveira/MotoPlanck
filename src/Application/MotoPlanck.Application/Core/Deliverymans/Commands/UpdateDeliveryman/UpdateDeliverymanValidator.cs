using FluentValidation;
using MotoPlanck.Application.Validations;
using MotoPlanck.Domain.Core.Enums;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Application.Core.Deliverymans.Commands.UpdateDeliveryman
{
    public sealed class UpdateDeliverymanValidator : AbstractValidator<UpdateDeliverymanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeliverymanValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(command => command.Id)
                .NotNull().WithErrorCode(ValidationErros.Deliveryman.IdNull.Code).WithMessage(ValidationErros.Deliveryman.IdNull.Message)
                .MustAsync(ExistsDeliveryman).WithErrorCode(ValidationErros.Deliveryman.ExistsDeliveryman.Code).WithMessage(ValidationErros.Deliveryman.ExistsDeliveryman.Message);

            RuleFor(command => command.Cnpj)
                .NotEmpty().WithErrorCode(ValidationErros.Deliveryman.CnpjEmpty.Code).WithMessage(ValidationErros.Deliveryman.CnpjEmpty.Message)
                .Length(14).WithErrorCode(ValidationErros.Deliveryman.CnpjLength.Code).WithMessage(ValidationErros.Deliveryman.CnpjLength.Message)
                .MustAsync(NoExistsCnpj).WithErrorCode(ValidationErros.Deliveryman.ExistsCnpj.Code).WithMessage(ValidationErros.Deliveryman.ExistsCnpj.Message);

            RuleFor(command => command.Cnh)
                .NotEmpty().WithErrorCode(ValidationErros.Deliveryman.CnhEmpty.Code).WithMessage(ValidationErros.Deliveryman.CnhEmpty.Message)
                .Length(9).WithErrorCode(ValidationErros.Deliveryman.CnhLength.Code).WithMessage(ValidationErros.Deliveryman.CnhLength.Message)
                .MustAsync(NoExistsCnh).WithErrorCode(ValidationErros.Deliveryman.ExistsCnh.Code).WithMessage(ValidationErros.Deliveryman.ExistsCnh.Message);

            RuleFor(command => command.TypeCnh)
                .NotEmpty().WithErrorCode(ValidationErros.Deliveryman.TypeCnhEmpty.Code).WithMessage(ValidationErros.Deliveryman.TypeCnhEmpty.Message)
                .MustAsync(OptionOfCnh).WithErrorCode(ValidationErros.Deliveryman.OptionsTypeCnh.Code).WithMessage(ValidationErros.Deliveryman.OptionsTypeCnh.Message);

            RuleFor(command => command.PictureCnhId)
                .NotEmpty().WithErrorCode(ValidationErros.Deliveryman.PictureCnhEmpty.Code).WithMessage(ValidationErros.Deliveryman.PictureCnhEmpty.Message);

            RuleFor(command => command.UserId)
                .NotNull().WithErrorCode(ValidationErros.Deliveryman.UserNull.Code).WithMessage(ValidationErros.Deliveryman.UserNull.Message)
                .MustAsync(ExistsUser).WithErrorCode(ValidationErros.Deliveryman.NoExistsUser.Code).WithMessage(ValidationErros.Deliveryman.NoExistsUser.Message);
        }

        private async Task<bool> ExistsDeliveryman(Guid id, CancellationToken cancellationToken) =>
            await _unitOfWork.Deliverymans.ExistsDeliverymanAsync(id, cancellationToken);

        private async Task<bool> NoExistsCnpj(string cnpj, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Deliverymans.ExistsCnpjAsync(cnpj, cancellationToken);
            return !response;
        }

        private async Task<bool> NoExistsCnh(string cnh, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Deliverymans.ExistsCnhAsync(cnh, cancellationToken);
            return !response;
        }

        private async Task<bool> ExistsUser(Guid userId, CancellationToken cancellationToken) =>
            await _unitOfWork.Users.ExistsUserAsync(userId, cancellationToken);

        private async Task<bool> OptionOfCnh(string optionsOfCnh, CancellationToken token)
        {
            try
            {
                ECnhType? typeCnhEnum = optionsOfCnh.ToEnum<ECnhType>(true);

                if (typeCnhEnum == null)
                    return await Task.FromResult(false);

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
