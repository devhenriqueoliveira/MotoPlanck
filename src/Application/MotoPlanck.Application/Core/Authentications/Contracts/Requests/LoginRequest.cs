namespace MotoPlanck.Application.Core.Authentications.Contracts.Requests
{
    public sealed class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
