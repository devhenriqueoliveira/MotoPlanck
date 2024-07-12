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
            internal static Error GetPlansOnDatabase => new(
              "Plan.GetPlansOnDatabase",
              "Unable to get plans in database");

            internal static Error GetPlanByIdOnDatabase => new(
              "Plan.GetPlanByIdOnDatabase",
              "Unable to get plan by id in database");

            internal static Error CreatePlanOnDatabase => new(
               "Plan.CreatePlanOnDatabase",
               "Unable to create plan in database");
            internal static Error UpdatePlanOnDatabase => new(
                "Plan.UpdatePlanOnDatabase",
                "Unable to update plan in database");
            internal static Error DeletePlanOnDatabase => new(
                "Plan.DeletePlanOnDatabase",
                "Unable to delete plan in database");

            internal static Error IdNull => new(
                "Plan.IdNull",
                "Identificator cannot be null.");

            internal static Error PlanNoExists => new(
                "Plan.PlanNoExists",
                "The plan is not exists.");

            internal static Error DayNull => new(
                "Plan.DayNull",
                "Day cannot be null.");
            internal static Error DayGreaterThanZero => new(
                "Plan.DayGreaterThanZero",
                "Day must be greater than 0.");

            internal static Error AmountNull => new(
                "Plan.AmountNull",
                "Amount cannot be null.");
            internal static Error AmountGreaterThanZero => new(
                "Plan.AmountGreaterThanZero",
                "Amount must be greater than 0.");

            internal static Error RatePercentageNull => new(
                "Plan.RatePercentageNull",
                "RatePercentage cannot be null.");
            internal static Error RatePercentageGreaterThanZero => new(
                "Plan.RatePercentageGreaterThanZero",
                "Rate percentage must be greater than 0.");
        }
    }
}
