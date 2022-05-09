using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.Commands
{
    public class AddCompany : IRequest<OperationResult<Company>>
    {
        public string Alias { get; set; }
        public string FullName { get; set; }
        public string CreatedBy { get; set; }
    }
}
