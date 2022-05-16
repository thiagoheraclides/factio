namespace Br.Com.FactIO.Api.Contracts.Address
{
    public class AddAddressRequest
    {
        public string ZipCode { get; set; }
        public string PublicName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Owner { get; set; }
    }
}
