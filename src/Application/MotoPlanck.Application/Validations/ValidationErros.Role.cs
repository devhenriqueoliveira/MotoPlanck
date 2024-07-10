using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Application.Validations
{
    /// <summary>
    /// Contains the application layer validation errors.
    /// </summary>
    internal static partial class ValidationErros
    {
        /// <summary>
        /// Contains the validation errors of role.
        /// </summary>
        internal static class Role
        {
            internal static Error CreateRoleOnDatabase => new(
                "Role.CreateRoleOnDatabase",
                "Unable to create role in database");
            internal static Error UpdateRoleOnDatabase => new(
                "Role.UpdateRoleOnDatabase",
                "Unable to update role in database");
            internal static Error DeleteRoleOnDatabase => new(
                "Role.DeleteRoleOnDatabase",
                "Unable to delete role in database");
        }
    }
}
