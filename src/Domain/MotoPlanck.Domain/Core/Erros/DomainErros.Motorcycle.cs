using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Domain.Core.Erros
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static partial class DomainErros
    {
        /// <summary>
        /// Contains the Motorcycle errors.
        /// </summary>
        public static class Motorcycle
        {
            /// <summary>
            /// Gets the motorcycle year is out of valid range.
            /// </summary>
            public static Error YearIsOutOfValidRange => new (
                "Motorcycle.YearIsOutOfValidRange",
                "The motorcycle year is not valid, as it is outside the valid range");

            /// <summary>
            /// Gets the motorcycle model is empty or null.
            /// </summary>
            public static Error ModelIsEmptyOrNull => new(
                "Motorcycle.ModelIsEmptyOrNull",
                "The motorcycle model is not valid, because it is empty or null");

            /// <summary>
            /// Gets the motorcycle plate is empty or null.
            /// </summary>
            public static Error PlateIsEmptyOrNull => new(
                "Motorcycle.PlateIsEmptyOrNull",
                "The motorcycle plate is not valid, because it is empty or null");
        }
    }
}
