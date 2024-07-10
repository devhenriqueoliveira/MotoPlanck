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
                Roles r ON u.RoleId = r.Id";
    }
}
