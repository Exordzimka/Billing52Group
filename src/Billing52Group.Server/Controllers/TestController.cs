using Microsoft.AspNetCore.Mvc;

namespace Billing52Group.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult OkGoogle() => Ok(new {Ok = "Google"});
    }
}
