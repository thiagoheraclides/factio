namespace Br.Com.FactIO.Api.Contracts.Category
{
    public class UpdateCategoryRequest
    {
        public Guid CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
