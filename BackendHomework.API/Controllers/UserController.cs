using Microsoft.AspNetCore.Mvc;

namespace BackendHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            
       
            return Ok("User Controller works !!");
        }
    }
}
