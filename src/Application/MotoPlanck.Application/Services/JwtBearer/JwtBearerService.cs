using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MotoPlanck.Application.Core.Authentications.Contracts.Responses;
using MotoPlanck.Domain.Core.Constants;
using MotoPlanck.Domain.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotoPlanck.Application.Services.JwtBearer
{
    public sealed class JwtBearerService(IConfiguration configuration) : IJwtBearerService<LoginAuthenticationResponse>
    {
        private readonly JwtSettings _settings = configuration.GetSection(SettingsConstants.JWT_SETTINGS).Get<JwtSettings>() ?? new JwtSettings();

        public async Task<string> GenerateTokenAsync(LoginAuthenticationResponse user, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.GetKey());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                ]),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

        public Task<List<string>> ValidateTokenAsync(string token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
