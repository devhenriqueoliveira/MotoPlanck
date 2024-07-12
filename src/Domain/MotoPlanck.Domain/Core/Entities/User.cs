using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class User : Entity
    {

        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Role Role { get; private set; }

        #endregion

        #region Constructors
        public User(string firstName, string lastName, string login, string password, string email, DateTime birthDate, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = SetHash(password);
            Email = email;
            BirthDate = birthDate;
            Role = role;
        }

        public User(Guid id, string firstName, string lastName, string login, string password, string email, DateTime birthDate, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = SetHash(password);
            Email = email;
            BirthDate = birthDate;
            Role = role;
        }

        public User()
        {
            
        }
        #endregion

        #region Public Methods
        public void CreateRole(Role role) => Role = role;
        #endregion

        private static string SetHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
