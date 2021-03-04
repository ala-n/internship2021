using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using MediatR;

namespace Xdl.Internship.Authentication.Handlers.VerifyToken
{
    public class VerifyTokenRequest : IRequest<DTOs.User>
    {
        public VerifyTokenRequest(Claim username)
        {
            Username = username;
        }

        public Claim Username { get; }
    }
}
