namespace Br.Com.FactIO.Domain.Entities
{
    public class Status : BaseEntity
    {
        public Guid CompanyId { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        private Status() { }

        public static Status CreateStatus(Guid companyId, string name, string createdBy)
        {
            return new Status
            {
                Id = Guid.NewGuid(),
                CompanyId = companyId,
                Name = name,
                Active = true,
                CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow,
            };
        }

        public void UpdateStatus(string name, string lastUpdatedBy)
        {            
            Name = name;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.UtcNow;
        }

        public void DeleteStatus(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.UtcNow;
        }
    }
}
