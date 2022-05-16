namespace Br.Com.FactIO.Api.Contracts.Zone
{
    public class AddZoneRequest
    {
        public string CompanyId { get; set; }
        public string AreaId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
