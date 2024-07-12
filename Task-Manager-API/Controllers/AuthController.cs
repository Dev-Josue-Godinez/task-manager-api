using Microsoft.AspNetCore.Mvc;

namespace Task_Manager_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet, ActionName("Get")]
        public string Get()
        {
            return "";
        }

        [HttpGet("Test"), ActionName("Test")]
        public string Test()
        {
            return "";
        }

    }
}
