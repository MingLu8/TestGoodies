using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace TestGoodies.Tests
{
    public class DummyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() { return Ok(); }
    }

    public class ControllerExtensionTests
    {
        [Fact]
        public void HttpContextTest()
        {
            var controller = new DummyController();
            controller.MockHttpContext("https", "localhost", 100, new Dictionary<string, string> { ["Origin"] = "http://dummy.com" });

            controller.Request.Scheme.Should().Be("https");
            controller.Request.Host.Value.Should().Be("localhost:100");
            controller.Request.Headers.ContainsKey("Origin").Should().BeTrue();
            controller.Request.Headers["Origin"].ToString().Should().Be("http://dummy.com");

        }
    }
    public class ConfigurationExtensionTests
    {
        [Fact]
        public void AddSection_with_string_value()
        {
            var config = Substitute.For<IConfiguration>().AddSection("a", "b");
            config.GetSection("a").Value.Should().Be("b");
        }
    }
}
