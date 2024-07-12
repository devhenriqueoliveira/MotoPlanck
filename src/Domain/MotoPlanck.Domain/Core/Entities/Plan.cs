using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Plan : Entity
    {
        #region Properties
        public int Day { get; private set; }
        public decimal Amount { get; private set; }
        public int RatePercentage { get; private set; }

        #endregion

        #region Constructors
        public Plan(Guid id, int day, decimal amount, int ratePercentage)
        {
            Ensure.NotNull(id, "Identificator is required.", nameof(id));
            Ensure.NotNull(day, "Day is required.", nameof(day));
            Ensure.NotNull(amount, "Amount is required.", nameof(amount));
            Ensure.NotNull(ratePercentage, "Rate percentage is required.", nameof(ratePercentage));

            Id = id;
            Day = day;
            Amount = amount;
            RatePercentage = ratePercentage;
        }

        public Plan(int day, decimal amount, int ratePercentage)
        {
            Ensure.NotNull(day, "Day is required.", nameof(day));
            Ensure.NotNull(amount, "Amount is required.", nameof(amount));
            Ensure.NotNull(ratePercentage, "Rate percentage is required.", nameof(ratePercentage));

            Day = day;
            Amount = amount;
            RatePercentage = ratePercentage;
        }

        /// <summary>
        /// To Dapper
        /// </summary>
        public Plan()
        {
            
        }
        #endregion
    }
}
