namespace Br.Com.FactIO.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public UserType UserType { get; private set; }
        public UserRole UserRole { get; private set; }
        public bool Active { get; private set; }
        private User() { }

        public static User CreateUser(string username, string password, string firstName, string lastName,
                                        UserRole userRole, UserType userType, string loggedUser)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                UserRole = userRole,
                UserType= userType,
                Active = true,
                CreatedBy = loggedUser,
                CreatedOn = DateTime.Now
            };
        }

        public void AddUserRole(UserRole userRole)
        {
            this.UserRole = userRole;
        }

        public void AddUserType(UserType userType)
        {
            this.UserType = userType;
        }
    }
}
