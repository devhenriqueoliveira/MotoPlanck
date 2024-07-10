using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of motorcycle.
        /// </summary>
        internal static class Motorcycle
        {
            internal static Error CreateMotorcycleOnDatabase => new(
              "Motorcycle.CreateMotorcycleOnDatabase",
              "Unable to create motorcycle in database");
            internal static Error UpdateMotorcycleOnDatabase => new(
                "Motorcycle.UpdateMotorcycleOnDatabase",
                "Unable to update motorcycle in database");
            internal static Error DeleteMotorcycleOnDatabase => new(
                "Motorcycle.DeleteMotorcycleOnDatabase",
                "Unable to delete motorcycle in database");
        }
    }
}
