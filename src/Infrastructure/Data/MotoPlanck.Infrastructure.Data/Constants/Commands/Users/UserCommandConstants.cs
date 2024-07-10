namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Users
{
    public static class UserCommandConstants
    {
        public const string CREATE_USER = "INSERT INTO Users (Id, FirstName, LastName, Login, Password, Email, BirthDate, RoleId) VALUES (@Id, @FirstName, @LastName, @Login, @Password, @Email, @BirthDate, @RoleId)";
    }
}
