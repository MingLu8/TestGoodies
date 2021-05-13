using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace TestGoodies
{
    public static class ConfigurationExtensions
    {
        public static IConfiguration AddSection(this IConfiguration configuration, string key, string value)
        {
            var section = Substitute.For<IConfigurationSection>();
            section.Key.Returns(key);
            section.Value.Returns(value);
            configuration.GetSection(key).Returns(section);
            return configuration;
        }
    }
}