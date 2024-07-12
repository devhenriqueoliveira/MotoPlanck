namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Users
{
    public static class UserCommandConstants
    {
        public const string CREATE_USER = "INSERT INTO Users (Id, FirstName, LastName, Login, Password, Email, BirthDate, RoleId) VALUES (@Id, @FirstName, @LastName, @Login, @Password, @Email, @BirthDate, @RoleId)";
        public const string UPDATE_USER = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Login = @Login, Email = @Email, BirthDate = @BirthDate, RoleId = @RoleId WHERE Id = @Id";
        public const string DELETE_USER = "DELETE FROM Users WHERE Id = @Id";
    }
}
