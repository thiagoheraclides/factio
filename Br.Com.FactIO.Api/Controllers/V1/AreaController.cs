using Br.Com.FactIO.Api.Contracts.Area;
using Br.Com.FactIO.Api.Controllers.V1;
using Br.Com.FactIO.Application.Areas.Command;
using Br.Com.FactIO.Application.Areas.Query;
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
    public class AreaController : BaseController
    {
        private readonly IMediator _mediator;

        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ApiRoutes.Area.Id)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetAreaByIdQuery { Id = Guid.Parse(id) };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllAreasQuery(), cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPost]
        [Route(ApiRoutes.Area.Add)]
        public async Task<IActionResult> Add([FromBody] AddAreaRequest request, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new AddAreaCommand
            {
                Code = request.Code,
                Description = request.Description,
                Notes = request.Notes,
                CompanyId = request.CompanyId,
                SiteId = request.SiteId,
                CreatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPatch]
        [Route(ApiRoutes.Area.Id)]
        public async Task<IActionResult> Update([FromBody] UpdateAreaRequest request, string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new UpdateAreaCommand
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
            var command = new DeleteAreaCommand
            {
                Id = id,
                DeletedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }
    }
}
