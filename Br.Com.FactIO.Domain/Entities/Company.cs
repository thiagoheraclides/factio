namespace Br.Com.FactIO.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Alias { get; private set; }
        public string FullName { get; private set; }
        public bool Active { get; private set; }
        private Company() { }

        public static Company CreateCompany(string alias, string fullName, string createdBy)
        {
            return new Company 
            {
                Id = Guid.NewGuid(),
                Alias = alias,
                FullName = fullName,
                Active = true,
                CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow
            };
        }
        public void UpdateCompany(string alias, string fullName, string lastUpdatedBy)
        {
            Alias = alias;
            FullName = fullName;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.UtcNow;
        }

        public void DeleteCompany(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.UtcNow;
        }
    }
}
