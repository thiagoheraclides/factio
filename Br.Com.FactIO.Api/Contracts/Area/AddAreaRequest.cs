namespace Br.Com.FactIO.Api.Contracts.Area
{
    public class AddAreaRequest
    {
        public string CompanyId { get; set; }
        public string SiteId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }        
    }
}
