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
            #region Id
            internal static Error IdNull => new(
                "User.IdNull",
                "The id cannot be null.");
            internal static Error UserNoExists => new(
                "User.UserNoExists",
                "The user not exists.");

            #endregion

            #region FirstName
            internal static Error FirstNameEmpty => new(
                "User.FirstNameEmpty",
                "The first name is required.");
            internal static Error FirstNameLength => new(
                "User.FirstNameLength",
                "The first name must be between 2 and 30 characters.");
            #endregion

            #region LastName
            internal static Error LastNameEmpty => new(
                "User.LastNameEmpty",
                "The last name is required.");
            internal static Error LastNameLength => new(
                "User.LastNameLength",
                "The last name must be between 2 and 30 characters.");
            #endregion

            #region Login
            internal static Error LoginEmpty => new(
                "User.LoginEmpty",
                "The login is required.");
            internal static Error LoginLength => new(
                "User.LoginLength",
                "The login must be between 2 and 18 characters.");
            internal static Error LoginExists => new(
                "User.LoginExists",
                "The login already exists.");
            #endregion

            #region Password
            internal static Error PasswordEmpty => new(
                "User.PasswordEmpty",
                "The password is required.");
            internal static Error PasswordLength => new(
                "User.PasswordLength",
                "The password must be between 2 and 30 characters.");
            internal static Error PasswordInvalid => new(
                "User.PasswordInvalid",
                "The password is invalid.");
            #endregion

            #region Email
            internal static Error EmailEmpty => new(
                "User.EmailEmpty",
                "The email is required.");
            internal static Error EmailIsNotValid => new(
                "User.EmailIsNotValid",
                "The email must be a valid email.");
            internal static Error EmailExists => new(
                "User.EmailExists",
                "The email already exists.");
            #endregion

            #region BirthDate
            internal static Error BirthDateNull => new(
                "User.BirthDateNull",
                "The birth date cannot be null.");
            internal static Error BirthDateIsNotValid => new(
                "User.BirthDateIsNotValid",
                "The birth date must be a valid date, age must be over 18.");
            #endregion

            #region Roles
            internal static Error RoleNull => new(
                "User.RoleNull",
                "The role cannot be null.");
            internal static Error NoExistsRole => new(
                "User.NoExistsRole",
                "The role is not exists.");
            #endregion
        }
    }
}
