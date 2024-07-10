using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of Rent.
        /// </summary>
        internal static class Rent
        {
            internal static Error CreateRentOnDatabase => new(
                "Rent.CreateRentOnDatabase",
                "Unable to create rent in database");
            internal static Error UpdateRentOnDatabase => new(
                "Rent.UpdateRentOnDatabase",
                "Unable to update rent in database");
            internal static Error DeleteRentOnDatabase => new(
                "Rent.DeleteRentOnDatabase",
                "Unable to delete rent in database");
        }
    }
}
