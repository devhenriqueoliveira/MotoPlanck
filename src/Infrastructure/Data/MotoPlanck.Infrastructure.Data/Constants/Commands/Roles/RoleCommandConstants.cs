namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Roles
{
    public static class RoleCommandConstants
    {
        public const string CREATE_ROLE = "INSERT INTO Roles (Id, Name, Description, Active) VALUES (@Id, @Name, @Description, @Active)";
        public const string UPDATE_ROLE = "UPDATE Roles SET Name = @Name, Description = @Description, Active = @Active WHERE Id = @Id";
        public const string DELETE_ROLE = "DELETE FROM Roles WHERE Id = @Id";
    }
}
