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
        }
    }
}
