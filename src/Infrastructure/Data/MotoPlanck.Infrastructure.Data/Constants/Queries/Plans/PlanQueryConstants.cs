namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Plans
{
    internal static class PlanQueryConstants
    {
        internal const string EXISTS_PLAN_BY_ID = "SELECT COUNT(1) FROM Plans WHERE Id = @Id;";
        internal const string GET_PLANS = "SELECT Id, Day, Amount, RatePercentage FROM Plans;";
        internal const string GET_PLAN_BY_ID = "SELECT Id, Day, Amount, RatePercentage FROM Plans WHERE Id = @Id;";

    }
}
