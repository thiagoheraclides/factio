namespace Br.Com.FactIO.Domain.Entities
{
    public class Site : BaseEntity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Notes { get; private set; }
        public bool Active { get; private set; }
        public Guid CompanyId { get; private set; }

        private Site() { }

        public static Site CreateSite(string code, string name, string notes, string companyId, string createdby)
        {
            return new Site 
            {
                Id = Guid.NewGuid(),
                Code = code,
                Name = name,
                Notes = notes,
                Active = true,
                CompanyId = Guid.Parse(companyId),
                CreatedBy = createdby,
                CreatedOn = DateTime.Now
            };
        }

        public void UpdateSite(string code, string name, string notes, string lastUpdatedBy)
        {
            Code = code;
            Name = name;
            Notes = notes;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.Now;
        }

        public void DeleteSite(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.Now;
        }
    }
}
