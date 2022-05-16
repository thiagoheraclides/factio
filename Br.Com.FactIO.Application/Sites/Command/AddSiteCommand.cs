using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.Command
{
    public class AddSiteCommand : IRequest<OperationResult<Site>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string CompanyId { get; set; }
        public string CreatedBy { get; set; }
    }
}
