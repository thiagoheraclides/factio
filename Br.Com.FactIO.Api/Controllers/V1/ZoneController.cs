using Br.Com.FactIO.Api.Contracts.Zone;
using Br.Com.FactIO.Application.Zones.Command;
using Br.Com.FactIO.Application.Zones.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FactIO.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ZoneController : BaseController
    {
        private readonly IMediator _mediator;

        public ZoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ApiRoutes.Zone.Id)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetZoneByIdQuery { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllZonesQuery(), cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPost]
        [Route(ApiRoutes.Zone.Add)]
        public async Task<IActionResult> Add([FromBody] AddZoneRequest request, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new AddZoneCommand
            {
                CompanyId = request.CompanyId,
                AreaId = request.AreaId,
                Code = request.Code,
                Description = request.Description,
                Notes = request.Notes,
                CreatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPatch]
        [Route(ApiRoutes.Zone.Id)]
        public async Task<IActionResult> Update([FromBody] UpdateZoneRequest request, string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new UpdateZoneCommand
            {
                Code = request.Code,
                Description = request.Description,
                Notes = request.Notes,
                LastUpdatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Area.Id)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new DeleteZoneCommand
            {
                Id = id,
                DeletedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }
    }
}
