using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Infrastructure.Data.Extensions.Users
{
    internal static class UserExtensions
    {
        internal static object MapFromParameters(this User user)
        {
            return new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Login,
                user.Password,
                user.Email,
                user.BirthDate,
                RoleId = user.Role.Id
            };
        }
    }
}
