using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Deliverymans.Contracts.Responses
{
    /// <summary>
    /// Represents the contract of deliveryman response.
    /// </summary>
    public class DeliverymanResponse
    {
        /// <summary>
        /// Gets or sets the deliveryman identificator.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

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
    }
}
