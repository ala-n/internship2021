using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.Feature.Login
{
    public partial class Login
    {
        public class CommandHandler : IRequestHandler<Command, UserRead>
        {
            private readonly IUserRepository _authenticationRepository;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public CommandHandler(IUserRepository authenticationRepository, IMapper mapper, IMediator mediator)
            {
               _authenticationRepository = authenticationRepository;
               _mapper = mapper;
               _mediator = mediator;
            }

            public async Task<UserRead> Handle(Command request, CancellationToken cancellationToken = default)
            {
                var userCredentials = new UserCredentials(request.Login, request.Password);
                var user = await _authenticationRepository.LoginAsync(userCredentials, cancellationToken);
                if (user == null)
                {
                   throw new ArgumentNullException("Login or password is incorrect");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return _mapper.Map<UserRead>(user);
            }
        }
    }
}
