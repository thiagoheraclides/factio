namespace Br.Com.FactIO.Domain.Entities
{
    public class Contact : BaseEntity
    {
        private Contact () { }
        
        public string Description { get; private set; }
        public string Type { get; private set; }
        public bool Status { get; private set; }

        public static Contact CreateContact(Guid userId, string description, string type, string loggedUser)
        {
            return new Contact
            {
                Id = Guid.NewGuid(),
                Description = description,
                Type = type,
                CreatedOn = DateTime.Now,
                CreatedBy = loggedUser,
                Status = true
            };
        }

        public static Contact CreateContact(Guid id, string description, string type, bool status,
            string createdBy, DateTime createdOn, string lastUpdatedBy, DateTime lastUpdatedOn, string deletedBy, DateTime deletedOn)
        {
            return new Contact 
            {
                Id = id,                
                Description = description,
                Type = type,
                Status = status,
                CreatedBy = createdBy,
                CreatedOn = createdOn,
                LastUpdateBy = lastUpdatedBy,
                LastUpdateOn = lastUpdatedOn,
                DeletedBy = deletedBy,
                DeletedOn = deletedOn
            };
        }




    }
}
