using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialJWT.Interfaces;
using TutorialJWT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TutorialJWT.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationManager jWTAuthenticationManager;

        public AuthController(IAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
