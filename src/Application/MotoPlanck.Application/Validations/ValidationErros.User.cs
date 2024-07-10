using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of user.
        /// </summary>
        internal static class User
        {
            internal static Error CreateUserOnDatabase => new(
                "User.CreateUserOnDatabase",
                "Unable to create user in database");
            internal static Error UpdateUserOnDatabase => new(
                "User.UpdateUserOnDatabase",
                "Unable to update user in database");
            internal static Error DeleteUserOnDatabase => new(
                "User.DeleteUserOnDatabase",
                "Unable to delete user in database");
        }
    }
}
