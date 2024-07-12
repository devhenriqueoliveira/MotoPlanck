using MotoPlanck.Domain.Core.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Roles.Contracts.Responses
{
    public sealed class RoleResponse
    {
        /// <summary>
        /// Gets or sets the role identificator.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the role active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

    }
}
