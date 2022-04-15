namespace Br.Com.FactIO.Domain.Entities
{
    public class UserType : BaseEntity
    {
        public string Type { get; private set; }
        public bool Active { get; private set; }
        private UserType() { }

        public static UserType CreateUserRole(string type, string loggedUser)
        {
            return new UserType
            {
                Id = Guid.NewGuid(),
                Type = type,
                Active = true,
                CreatedBy = loggedUser,
                CreatedOn = DateTime.UtcNow
            };
        }

    }
}
