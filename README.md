# TestGoodies
Contains helper methods for mocking and test assertions for tests.

## AddSection
``` C#
[Fact]
public void AddSectionTest()
{
    var config = Substitute.For<IConfiguration>().AddSection("a", "b");
    config.GetSection("a").Value.Should().Be("b");
}
```