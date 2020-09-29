using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationWithIntegrationTests.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [AllowAnonymous]
        public IActionResult HealthCheck()
        {
            return Ok();
        }
    }
}