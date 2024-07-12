namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Users
{
    public static class UserQueryConstants
    {
        public const string GET_ALL_USERS = @"SELECT 
                u.Id, u.FirstName, u.LastName, u.Login, u.Email, u.BirthDate, u.RoleId,
                r.Id, r.Name, r.Description, r.Active
            FROM 
                Users u
            INNER JOIN 
                Roles r ON u.RoleId = r.Id;";

        public const string GET_USER_BY_ID = @"SELECT 
                u.Id, u.FirstName, u.LastName, u.Login, u.Email, u.BirthDate, u.RoleId,
                r.Id, r.Name, r.Description, r.Active
            FROM 
                Users u
            INNER JOIN 
                Roles r ON u.RoleId = r.Id
            WHERE
                u.Id = @Id;";

        public const string GET_USER_BY_LOGIN = @"SELECT 
                u.Id, u.FirstName, u.LastName, u.Login, u.Password, u.Email, u.BirthDate, u.RoleId,
                r.Id, r.Name, r.Description, r.Active
            FROM 
                Users u
            INNER JOIN 
                Roles r ON u.RoleId = r.Id
            WHERE
                u.Login = @Login;";

        public const string EXISTS_USER = "SELECT COUNT(1) FROM Users WHERE Id = @Id;";
        public const string EXISTS_LOGIN = "SELECT COUNT(1) FROM Users WHERE Login = @Login;";
        public const string EXISTS_EMAIL = "SELECT COUNT(1) FROM Users WHERE Email = @Email;";
    }
}
