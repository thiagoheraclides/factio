using AutoMapper;
using Br.Com.FactIO.Api.Contracts.Identity;
using Br.Com.FactIO.Application.Identity.Commands;
using Br.Com.FactIO.Application.Identity.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Br.Com.FactIO.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IdentityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Register(UserRegistration userRegistration, CancellationToken cancellationToken)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return Ok();
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login(Credential credential, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(credential);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(_mapper.Map<UserProfile>(result.Payload));
        }


    }
}
