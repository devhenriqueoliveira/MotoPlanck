namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Roles
{
    public static class RoleQueryConstants
    {
        public const string EXISTS_IDENTIFICATOR = "SELECT COUNT(1) FROM Roles WHERE Id = @Id";
        public const string GET_ALL_ROLES = "SELECT Id, Name, Description, Active FROM Roles";
        public const string GET_ROLE_BY_ID = "SELECT Id, Name, Description, Active FROM Roles WHERE Id = @Id";
    }
}
