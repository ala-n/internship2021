using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.Handlers.Feature.Login
{
    public partial class Login
    {
        public class Command : IRequest<UserRead>
        {
            public string Login { get; }

            public string Password { get; }

            public Command(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }
    }
}
