using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Udemy.API.Controllers
{
    //Https://Localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Get : Https://Localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentnames = new string[] { "ravi", "shankar", "john", "Mark", "David" };
            return Ok(studentnames);
        }
    }
}
