using Microsoft.AspNetCore.Mvc;

namespace PipelineSample.WebApi.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Api");
        }
    }
}