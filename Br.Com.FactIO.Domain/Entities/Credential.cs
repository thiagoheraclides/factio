namespace Br.Com.FactIO.Domain.Entities
{
    public class Credential : BaseEntity
    {
        private Credential() { }

        public  string Login { get; private set; }
        public string Password { get; private set; }
        public bool Status { get; private set; }

        public static Credential CreateCredential(string login, string password, string loggedUser)
        {
            return new Credential
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password,
                CreatedOn = DateTime.Now,
                CreatedBy = loggedUser,
                Status = true
            };
        }

    }
}
