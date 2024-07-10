using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Deliverymans.Contracts.Requests
{
    /// <summary>
    /// Represents the contract to create a deliveryman.
    /// </summary>
    public sealed class CreateDeliverymanRequest
    {
        /// <summary>
        /// Gets or sets the deliveryman cnpj.
        /// </summary>
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }

        /// <summary>
        /// Gets or sets the deliveryman cnh.
        /// </summary>
        [JsonPropertyName("cnh")]
        public string Cnh { get; set; }

        /// <summary>
        /// Gets or sets the deliveryman cnpj.
        /// </summary>
        [JsonPropertyName("type_cnh")]
        public string TypeCnh { get; set; }

        /// <summary>
        /// Gets or sets the deliveryman cnpj.
        /// </summary>
        [JsonPropertyName("picture_cnh_id")]
        public string PictureCnhId { get; set; }

        /// <summary>
        /// Gets or sets the deliveryman user identificator.
        /// </summary>
        [JsonPropertyName("user_id")]
        public Guid UserId { get; set; }
    }
}
