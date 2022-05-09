namespace Br.Com.FactIO.Api.Contracts.CostCenter
{
    public class AddCostCenterRequest
    {
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
