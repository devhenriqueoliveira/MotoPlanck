using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Rent
    {
        public Rent(
            DateTime initialDate,
            DateTime finalDate, 
            DateTime forecastDate, 
            Deliveryman deliveryman, 
            Motorcycle motorcycle, 
            Plan plan)
        {
            Ensure.NotNull(initialDate, "Initial date is required.", nameof(initialDate));
            Ensure.NotNull(finalDate, "Final date is required.", nameof(initialDate));
            Ensure.NotNull(forecastDate, "Forecast date is required.", nameof(initialDate));
            Ensure.NotNull(deliveryman, "Deliveryman is required.", nameof(initialDate));
            Ensure.NotNull(motorcycle, "Motorcycle is required.", nameof(initialDate));
            Ensure.NotNull(plan, "Plan is required.", nameof(initialDate));

            InitialDate = initialDate;
            FinalDate = finalDate;
            ForecastDate = forecastDate;
            Deliveryman = deliveryman;
            Motorcycle = motorcycle;
            Plan = plan;
        }

        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        public DateTime ForecastDate { get; private set; }
        public Deliveryman Deliveryman { get; private set; }
        public Motorcycle Motorcycle { get; private set; }
        public Plan Plan { get; private set; }
    }
}
