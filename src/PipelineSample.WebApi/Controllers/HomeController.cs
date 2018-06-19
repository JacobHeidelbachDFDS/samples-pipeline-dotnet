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


        [HttpGet]
        [Route("/version")]
        public IActionResult GetVersion()
        { 
            var version = Environment.GetEnvironmentVariable("BUILDVERSION");
            return Ok(version ?? "0.0.0");
        }  
    }
}