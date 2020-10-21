using Microsoft.AspNetCore.Mvc;

namespace Billing52Group.Controllers.V1
{
    [ApiController]
    [Route("[area]/[controller]")]
    public sealed class TestController : V1ControllerBase
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
