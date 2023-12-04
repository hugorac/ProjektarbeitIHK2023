using Microsoft.AspNetCore.Mvc;

namespace DataProviderApi.Controllers
{
    public class HcController : ControllerBase {
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("App is running");
        }
    }
}
