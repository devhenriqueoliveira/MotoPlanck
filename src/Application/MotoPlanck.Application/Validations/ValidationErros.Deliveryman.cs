using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of deliveryman.
        /// </summary>
        internal static class Deliveryman
        {
            internal static Error CreateDeliverymanOnDatabase => new(
                "Deliveryman.CreateDeliverymanOnDatabase",
                "Unable to create deliveryman in database");
            internal static Error UpdateDeliverymanOnDatabase => new(
                "Deliveryman.UpdateDeliverymanOnDatabase",
                "Unable to update deliveryman in database");
            internal static Error DeleteDeliverymanOnDatabase => new(
                "Deliveryman.DeleteDeliverymanOnDatabase",
                "Unable to delete deliveryman in database");

            internal static Error IdNull => new(
                "Deliveryman.IdNull",
                "Id is required.");
            internal static Error ExistsDeliveryman => new(
                "Deliveryman.ExistsDeliveryman",
                "Deliveryman is not exists.");

            internal static Error CnpjEmpty => new(
                "Deliveryman.CnpjEmpty",
                "Cnpj is required.");
            internal static Error CnpjLength => new(
                "Deliveryman.CnpjLength",
                "Cnpj must be a 14 characters");
            internal static Error ExistsCnpj => new(
                "Deliveryman.ExistsCnpj",
                "The Cnpj already exists");

            internal static Error CnhEmpty => new(
                "Deliveryman.CnhEmpty",
                "Cnh is required.");
            internal static Error CnhLength => new(
                "Deliveryman.CnhLength",
                "Cnh must be a 9 characters.");
            internal static Error ExistsCnh => new(
                "Deliveryman.ExistsCnh",
                "The Cnh already exists.");

            internal static Error TypeCnhEmpty => new(
                "Deliveryman.TypeCnhEmpty",
                "Type of Cnh is required.");
            internal static Error OptionsTypeCnh => new(
                "Deliveryman.OptionsTypeCnh",
                "The type cnh option is invalid, select: A, B or AB");

            internal static Error PictureCnhEmpty => new(
              "Deliveryman.PictureCnhEmpty",
              "The picture of Cnh is required.");

            internal static Error UserNull => new(
              "Deliveryman.UserNull",
              "The user of deliveryman is not be null.");
            internal static Error NoExistsUser => new(
              "Deliveryman.NoExistsUser",
              "The user selected is not exists.");
        }
    }
}
