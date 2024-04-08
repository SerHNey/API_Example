using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Example.Controllers
{
    [Route("api/user1")]
    [ApiController]
    public class User1Controller : ControllerBase
    {
        private static string[] users1 = new[]
        {
            "Oleg", "Ivan", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static object[] users2 = new[]
        {
              new {Name = "Chilly" },
              new {Name = "Cool" }
        };

        [HttpGet]
        public IActionResult GetUsers1()
        {
            return Ok(users1);
        }
    }
}
