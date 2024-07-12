using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Users.Contracts.Requests
{
    /// <summary>
    /// The contract to update a user.
    /// </summary>
    public sealed class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user birth date.
        /// </summary>
        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; set; } = default!;

        /// <summary>
        /// Gets or sets the user roel id.
        /// </summary>
        [JsonPropertyName("role_id")]
        public Guid RoleId { get; set; } = Guid.Empty;
    }
}
