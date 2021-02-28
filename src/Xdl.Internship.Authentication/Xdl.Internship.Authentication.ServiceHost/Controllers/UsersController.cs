using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Authentication.DTOs;
using Xdl.Internship.Authentication.Handlers.Login;

namespace Xdl.Internship.Authentication.ServiceHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentials credentials)
        {
            if (credentials == null)
            {
                return BadRequest("No data");
            }

            var authInfo = await _mediator.Send(new LoginRequest(credentials.Login, credentials.Password));

            if (string.IsNullOrEmpty(authInfo?.Token))
            {
                return BadRequest("Error login or password");
            }

            return Ok(authInfo);
        }
    }
}
