using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.Login
{
        public class LoginRequest : IRequest<UserAuthInfo>
        {
            public string Login { get; }

            public string Password { get; }

            public LoginRequest(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }
}
