using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Infrastructure.Data.Extensions.Users
{
    public static class UserExtensions
    {
        public static object MapFromParameters(this User user)
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
