namespace Br.Com.FactIO.Domain.Entities
{
    public class Area : BaseEntity
    {
        public Guid CompanyId { get; private set; }
        public Guid SiteId { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }        
        public bool Active { get; private set; }

        private Area() { }

        public static Area CreateArea(string companyId, string siteId, string code, string description, string notes, string createdBy)
        {
            return new Area
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse(companyId),
                SiteId = Guid.Parse(siteId),
                Code = code,
                Description = description,
                Notes = notes,                
                Active = true,
                CreatedBy = createdBy,
                CreatedOn = DateTime.Now
            };
        }

        public void UpdateArea(string code, string description, string notes, string lastUpdatedBy)
        {
            Code = code;
            Description = description;
            Notes = notes;            
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.Now;
        }

        public void DeleteArea(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.Now;
        }

    }
}
