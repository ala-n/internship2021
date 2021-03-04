using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.VerifyToken
{
    public class VerifyTokenHandler : IRequestHandler<VerifyTokenRequest, DTOs.User>
    {
        private readonly IUserRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public VerifyTokenHandler(IUserRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<DTOs.User> Handle(VerifyTokenRequest request, CancellationToken cancellationToken)
        {
           var user = await _authenticationRepository.FindUsersAsync(x => x.FirstName == request.Username.Value);

           return _mapper.Map<DTOs.User>(user);
        }
    }
}
