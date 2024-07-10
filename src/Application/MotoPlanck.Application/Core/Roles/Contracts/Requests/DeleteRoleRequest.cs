using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Roles.Contracts.Requests
{
    /// <summary>
    /// Represents the delete role request.
    /// </summary>
    public sealed class DeleteRoleRequest
    {
        /// <summary>
        /// Gets or sets the role identificator.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
