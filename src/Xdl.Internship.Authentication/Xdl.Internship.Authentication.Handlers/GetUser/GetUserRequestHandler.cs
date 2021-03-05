using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.GetUser
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, DTOs.User>
    {
        private readonly IUserRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public GetUserRequestHandler(IUserRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<DTOs.User> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _authenticationRepository.FindOneUserByIdAsync(new ObjectId(request.Id));
            return _mapper.Map<DTOs.User>(user);
        }
    }
}
