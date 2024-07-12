using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Authentications.Contracts.Responses
{
    public sealed class LoginAuthenticationResponse
    {
        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user birth date.
        /// </summary>
        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the user token.
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
