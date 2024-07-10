using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Roles.Contracts.Requests
{
    /// <summary>
    /// Represents the update role request.
    /// </summary>
    public sealed class UpdateRoleRequest
    {
        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the role active status.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
