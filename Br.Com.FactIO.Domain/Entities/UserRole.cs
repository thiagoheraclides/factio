namespace Br.Com.FactIO.Domain.Entities
{
    public class UserRole : BaseEntity
    {       
        public string Role { get; private set; }
        public bool Active { get; private set; }
        private UserRole() { }

        public static UserRole CreateUserRole(string role, string loggedUser)
        {
            return new UserRole
            {
                Id = Guid.NewGuid(),
                Role = role,
                Active = true,
                CreatedBy = loggedUser,
                CreatedOn = DateTime.UtcNow
            }; 
        }
    }
}
