using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Example.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
              new {Name = "Oleg" },
              new {Name = "Ivan" }
            };
            return Ok(users);
        }
    }
}

// http://localhost:49196/