using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace API_Example.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            string query = @"
             SELECT sqehg
	            FROM public.message; ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnDb");
            NpgsqlDataReader myReader;
            using(NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource)) 
            {
                myCon.Open();
                using(NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader=myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

/*            var users = new[]
            {
              new {Name = "Oleg" },
              new {Name = "Ivan" }
            };
            return Ok(users);*/
        }
    }
}

// http://localhost:49196/