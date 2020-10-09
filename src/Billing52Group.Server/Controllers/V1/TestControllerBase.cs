using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Billing52Group.Server.Controllers.V1
{
    [ApiController]
    [Route("[area]/[controller]")]
    public class TestControllerBase : V1ControllerBase
    {
        /// <summary>
        ///     Get { "Ok": "Google" }
        /// </summary>
        /// <response code="200">Returned success</response>
        [Produces("application/json")]
        [HttpGet]
        public IActionResult OkGoogle() => Ok(new {Ok = "Google"});
    }
}
