using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace TestGoodies.Tests
{
    public class ConfigurationExtensionTests
    {
        [Fact]
        public void AddSectionTest()
        {
            var config = Substitute.For<IConfiguration>().AddSection("a", "b");
            config.GetSection("a").Value.Should().Be("b");
        }
    }
}
