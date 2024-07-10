using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class User : Entity
    {
        public User(string firstName, string lastName, string login, string password, string email, DateTime birthDate, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            Role = role;
        }

        public User()
        {
            
        }

        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Role Role { get; private set; }

        #endregion

        public void SetRole(Role role) => Role = role;
    }
}
