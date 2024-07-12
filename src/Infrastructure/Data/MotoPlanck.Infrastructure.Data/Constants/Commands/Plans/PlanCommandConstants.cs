namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Plans
{
    internal static class PlanCommandConstants
    {
        internal const string CREATE_PLAN = "INSERT INTO Plans (Id, Day, Amount, RatePercentage) VALUES (@Id, @Day, @Amount, @RatePercentage);";
        internal const string UPDATE_PLAN = "UPDATE Plans SET Day = @Day, Amount = @Amount, RatePercentage = @RatePercentage WHERE Id = @Id;";
        internal const string DELETE_PLAN = "DELETE FROM Plans WHERE Id = @Id;";
    }
}
