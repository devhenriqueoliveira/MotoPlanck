namespace MotoPlanck.Application.Core.Rentals.Contracts.Requests
{
    public sealed class CreateRentRequest
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public Guid DeliverymanId { get; set; }
        public Guid MotorcycleId { get; set; }
        public Guid PlanId { get; set; }
    }
}
