using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of Plan.
        /// </summary>
        internal static class Plan
        {
            internal static Error CreatePlanOnDatabase => new(
               "Plan.CreatePlanOnDatabase",
               "Unable to create plan in database");
            internal static Error UpdatePlanOnDatabase => new(
                "Plan.UpdatePlanOnDatabase",
                "Unable to update plan in database");
            internal static Error DeletePlanOnDatabase => new(
                "Plan.DeletePlanOnDatabase",
                "Unable to delete plan in database");
        }
    }
}
