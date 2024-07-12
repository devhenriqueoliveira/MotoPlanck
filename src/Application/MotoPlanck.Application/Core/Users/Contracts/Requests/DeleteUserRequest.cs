using System.Text.Json.Serialization;

namespace MotoPlanck.Application.Core.Users.Contracts.Requests
{
    public sealed class DeleteUserRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
