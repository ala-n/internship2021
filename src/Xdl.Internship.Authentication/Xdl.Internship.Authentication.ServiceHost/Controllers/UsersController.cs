using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;
using Xdl.Internship.Authentication.Models;

namespace Xdl.Internship.Authentication.ServiceHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _authenticationRepository;

        public UsersController(IUserRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentials userCredentials)
        {
            var user = await _authenticationRepository.LoginAsync(userCredentials, default);
            if (user == null)
            {
                return BadRequest(new { message = "Login or password is incorrect" });
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
            return Ok(user);
        }
    }
}
