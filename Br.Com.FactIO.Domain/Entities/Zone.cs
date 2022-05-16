using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FactIO.Domain.Entities
{
    public class Zone : BaseEntity
    {
        public Guid CompanyId { get; private set; }
        public Guid AreaId { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }
        public bool Active { get; private set; }

        private Zone() { }

        public static Zone CreateZone(string companyId, string areaId, string code, string description, string notes, string createdBy)
        {
            return new Zone
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse(companyId),
                AreaId = Guid.Parse(areaId),
                Code = code,
                Description = description,
                Notes = notes,
                Active = true,
                CreatedBy = createdBy,
                CreatedOn = DateTime.Now
            };
        }

        public void UpdateZone(string code, string description, string notes, string lastUpdatedBy)
        {
            Code = code;
            Description = description;
            Notes = notes;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.Now;
        }

        public void DeleteZone(string deletedBy)
        {
            Active = false;
            DeletedBy = deletedBy;
            DeletedOn = DateTime.Now;
        }
    }
}
