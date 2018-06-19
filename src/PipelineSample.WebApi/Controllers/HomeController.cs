using Microsoft.AspNetCore.Mvc;
using System;

namespace PipelineSample.WebApi.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var connString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            return Ok($"Hello from Api - using var {connString}");
        }
    }
}