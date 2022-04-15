using AutoMapper;
using Br.Com.FactIO.Application.Identity.Commands;
using Br.Com.FactIO.Application.Identity.Dtos;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Application.Services;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Br.Com.FactIO.Application.Identity.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<UserProfile>>
    {

        private readonly IMapper _mapper;        
        private readonly IdentityService _identityService;
        private readonly IUnitOfWork _unitOfWork;
        private OperationResult<UserProfile> _result = new();

        public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IdentityService identityService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _identityService = identityService;
        }

        public async Task<OperationResult<UserProfile>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await GetAndValidateUser(request);
            if (_result.IsError) return _result;

            var role = await _unitOfWork.UserRoleRepository.GetByIdAsync(user.Id);
            user.AddUserRole(role);

            var type = await _unitOfWork.UserTypeRepository.GetByIdAsync(user.Id);
            user.AddUserType(type);

            _result.Payload = new UserProfile();
            _result.Payload.Id = user.Id.ToString();
            _result.Payload.UserName = user.UserName;
            _result.Payload.FirstName = user.FirstName;
            _result.Payload.LastName = user.LastName;
            _result.Payload.TypeId = user.UserType.Id.ToString();
            _result.Payload.TypeDesccription = user.UserType.Type;
            _result.Payload.RoleId = user.UserRole.Id.ToString();
            _result.Payload.RoleDescription = user.UserRole.Role;
            _result.Payload.Token = GetJwtString(user);
           
            return _result;
        }

        private async Task<User> GetAndValidateUser(LoginCommand request)
        {
            var user = await _unitOfWork.UserRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                _result.AddError(700, "Invalid credential: username.");

            var isValid = await _unitOfWork.UserRepository.CheckPasswordAsync(request.UserName, request.Password);
            if (!isValid)
                _result.AddError(700, "Invalid credential: password.");

            return user;
        }  

        private string GetJwtString(User user)
        {
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}")
            });

            var token = _identityService.CreateSecurityToken(claimsIdentity);
            return _identityService.WriteToken(token);
        }


    }
}
