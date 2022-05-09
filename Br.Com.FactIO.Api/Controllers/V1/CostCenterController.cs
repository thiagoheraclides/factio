using AutoMapper;
using Br.Com.FactIO.Api.Contracts.CostCenter;
using Br.Com.FactIO.Application.CostCenters.Commands;
using Br.Com.FactIO.Application.CostCenters.Query;
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
    public class CostCenterController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CostCenterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.CostCenter.Id)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetCostCenterById { Id = Guid.Parse(id) };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result.Payload);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCostCenters(), cancellationToken);
            return Ok(result.Payload);
        }

        [HttpPost]
        [Route(ApiRoutes.CostCenter.Add)]
        public async Task<IActionResult> Add([FromBody] AddCostCenterRequest request, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new AddCostCenter
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
        [Route(ApiRoutes.CostCenter.Id)]
        public async Task<IActionResult> Update([FromBody] UpdateCostCenterRequest request, string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new UpdateCostCenter
            {
                CostCenterId = Guid.Parse(id),
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                LastUpdatedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.CostCenter.Id)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new DeleteCostCenter
            {
                CostCenterId = Guid.Parse(id),
                DeletedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }
    }
}
