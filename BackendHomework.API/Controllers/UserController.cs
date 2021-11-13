using Microsoft.AspNetCore.Mvc;

namespace BackendHomework.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        [Route("index")]
        public ActionResult Index()
        {
            return Ok();
        }
    }
}
