using AutoMapper;
using Br.Com.FactIO.Api.Contracts.Company;
using Br.Com.FactIO.Application.Companys.Commands;
using Br.Com.FactIO.Application.Companys.Query;
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
    public class CompanyController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompanyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.Company.Id)]        
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var command = new GetCompanyById { CompanyId = new Guid(id) };
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCompanys(), cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(result.Payload);
        }

        [HttpPost]
        [Route(ApiRoutes.Company.Add)]        
        public async Task<IActionResult> Create(AddCompanyRequest request, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = _mapper.Map<AddCompany>(request);
            command.CreatedBy = requestor;
            var result = await _mediator.Send(command,cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);
            return Ok(result.Payload);
        }

        [HttpPatch]
        [Route(ApiRoutes.Company.Id)]
        public async Task<IActionResult> Update([FromBody]CompanyUpdateRequest request, string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new UpdateCompany
            {
                CompanyId = Guid.Parse(id),
                Alias = request.Alias,
                FullName = request.FullName,
                LastUpdatedBy = requestor
            };            
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Company.Id)]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var requestor = HttpContext.User.Identity.Name;
            var command = new DeleteCompany
            {
                CompanyId = Guid.Parse(id),
                DeletedBy = requestor
            };
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

    }
}
