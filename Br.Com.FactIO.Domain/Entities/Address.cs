namespace Br.Com.FactIO.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid Owner { get; private set; }
        public string PublicName { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }        

        private Address() { }

        public static Address CreateAddress(string owner, string publicName, string zipCode, string city, string state, string country, string createdBy)
        {
            return new Address
            {
                Id = Guid.NewGuid(),
                Owner = Guid.Parse(owner),
                PublicName = publicName,
                ZipCode = zipCode,
                City = city,
                State = state,
                Country = country,
                CreatedBy = createdBy,
                CreatedOn = DateTime.Now
            };
        }

        public void UpdateAddress(string publicName, string zipCode, string city, string state, string country, string lastUpdatedBy)
        {
            PublicName = publicName;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = DateTime.Now;
        }

    }
}
