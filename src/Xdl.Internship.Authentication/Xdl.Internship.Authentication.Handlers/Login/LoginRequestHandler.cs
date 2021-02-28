using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.Login
{
        public class LoginRequestHandler : IRequestHandler<LoginRequest, UserAuthInfo>
        {
            private readonly IUserRepository _authenticationRepository;
            private readonly IMapper _mapper;
            private readonly JwtSecurityTokenHandler _securityTokenHandler;

            public LoginRequestHandler(IUserRepository authenticationRepository, IMapper mapper)
            {
               _authenticationRepository = authenticationRepository;
               _mapper = mapper;
               _securityTokenHandler = new JwtSecurityTokenHandler();
            }

            public async Task<UserAuthInfo> Handle(LoginRequest request, CancellationToken cancellationToken = default)
            {
            var result = new UserAuthInfo();

            var user = await _authenticationRepository.LoginAsync(request.Login, request.Password, cancellationToken);
            if (user != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Name, user.LastName),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                };
                var securityToken = _securityTokenHandler.CreateToken(tokenDescriptor);
                result.Token = _securityTokenHandler.WriteToken(securityToken);
                result.UserDetails = _mapper.Map<User>(user);
            }

            return result;
        }
    }
}
