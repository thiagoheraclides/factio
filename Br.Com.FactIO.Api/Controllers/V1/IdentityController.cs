using Br.Com.FactIO.Api.Contracts.Identity;
using Br.Com.FactIO.Application.Identity.Dtos;
using Br.Com.FactIO.Application.Services;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Type;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Br.Com.FactIO.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IdentityService _identityService;

        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration, CancellationToken cancellationToken)
        {
            var credential = Credential.CreateCredencial(userRegistration.UserName, userRegistration.Password, userRegistration.UserName);
            var user = Domain.Entities.User.CreateUser(userRegistration.FirstName, userRegistration.LastName, credential, UserType.Base, "admin");          

            var result = new IdentityUserDto
            {
                Username = userRegistration.UserName,
                Token = GetJwtString(user),
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login, CancellationToken cancellationToken)
        {
            return Ok();
        }

        private string GetJwtString(User user)
        {
            var claimIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Credential.Login),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            });

            var token = _identityService.CreateSecurityToken(claimIdentity);
            return _identityService.WriteToken(token);
 
        }
    }
}
