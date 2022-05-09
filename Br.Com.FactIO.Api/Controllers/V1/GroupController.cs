using AutoMapper;
using Br.Com.FactIO.Api.Contracts.Group;
using Br.Com.FactIO.Application.Groups.Commands;
using Br.Com.FactIO.Application.Groups.Query;
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
    public class GroupController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GroupController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.Group.Id)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetGroupById { Id = Guid.Parse(id) };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllGroups(), cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPost]
        [Route(ApiRoutes.Group.Add)]
        public async Task<IActionResult> Add([FromBody] AddGroupRequest request, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new AddGroup
            {
                CompanyId = Guid.Parse(request.CompanyId),
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                CreatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPatch]
        [Route(ApiRoutes.Group.Id)]
        public async Task<IActionResult> Update([FromBody] UpdateGroupRequest request, string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new UpdateGroup
            {
                GroupId = Guid.Parse(id),
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                LastUpdatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Group.Id)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new DeleteGroup
            {
                GroupId = Guid.Parse(id),
                DeletedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }
    }
}
