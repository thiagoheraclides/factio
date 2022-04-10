namespace Br.Com.FactIO.Domain.Entities
{
    public class Contact : BaseEntity
    {
        private Contact () { }

        public Guid UserId { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }
        public bool Status { get; private set; }

        public static Contact CreateContact(Guid userId, string description, string type, string loggedUser)
        {
            return new Contact 
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Description = description,
                Type = type,
                CreatedOn = DateTime.Now,
                CreatedBy = loggedUser,
                Status = true
            };
        }


    }
}
