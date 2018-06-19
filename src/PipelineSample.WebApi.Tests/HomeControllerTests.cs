using System;
using Xunit;
using PipelineSample.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PipelineSample.WebApi.Tests
{
    public class HomeControllerTests
    {
        private HomeController _sut;

        public HomeControllerTests()
        {
            _sut = new HomeController();
            
        }

        [Fact]
        public void TestThatGetReturnsHelloWorld()
        {
            // Act
            Environment.SetEnvironmentVariable("CONNECTIONSTRING","futte");
            var result = (OkObjectResult)_sut.Get();

            Assert.Equal("Hello from Api - using var futte",(string)result.Value);
        }
    }
}
