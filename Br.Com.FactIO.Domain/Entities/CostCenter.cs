namespace Br.Com.FactIO.Domain.Entities
{
    public class CostCenter : BaseEntity
    {
        public Guid CompanyId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        private CostCenter() { }

        public static CostCenter CreateCostCenter(Guid companyId, string code, string name, string description, string createdBy)
        {
            return new CostCenter
            {
                Id = Guid.NewGuid(),
                CompanyId = companyId,
                Code = code,
                Name = name,
                Description = description,
                Active = true,
                CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow,
            };
        }

        public void UpdateCostCenter(string code, string name, string description, string lastUpdatedBy)
        {
            Code = code;
            Name = name;
            Description = description;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.UtcNow;
        }

        public void DeleteCostCenter(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.UtcNow;
        }
    }
}
