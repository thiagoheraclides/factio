using Br.Com.FactIO.Application.Identity.Dtos;
using Br.Com.FactIO.Application.Models;
using MediatR;

namespace Br.Com.FactIO.Application.Identity.Commands
{
    public class LoginCommand : IRequest<OperationResult<UserProfile>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
