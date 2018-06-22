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
            return Ok($"Hello from Api  - using var {connString}");
        }


        [HttpGet]
        [Route("/version")]
        public IActionResult GetVersion()
        { 
            var version = Environment.GetEnvironmentVariable("BUILDVERSION");
            return Ok(new Version(version ?? "0.0.0"));
        }  
    }

    class Version
    {   
        public string VersionNumber { get; private set; }
        public Version(string version)
        {
            VersionNumber = version;
        }

    }
}