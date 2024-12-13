using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TutorialJWT.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TutorialJWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IAuthenticationManager jWTAuthenticationManager;

        public DataController(IAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }


        // GET: api/<DataController> 
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var claimIdentity = User.Identity;
            var claimPricipal = new ClaimsPrincipal(claimIdentity);
            var claim = claimPricipal.Claims.Select(c => new { c.Value }).ToList();
            string username = claim[0].Value.ToString();
            return new string[] { username, "Almand", "Teknologi" };
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
    }
}
