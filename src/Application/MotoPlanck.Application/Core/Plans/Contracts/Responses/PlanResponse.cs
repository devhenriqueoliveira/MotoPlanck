using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Plans.Contracts.Responses
{
    public sealed class PlanResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("rate_percentage")]
        public int RatePercentage { get; set; }
    }
}
