using FluentAssertions;
using MediatR;
using Xunit;

namespace MyDotNetEventSourcedProject;

public class EventsDefinitionTests
{
    [Fact]
    [Trait("Category", "SkipCI")]
    public void AllEventTypes_ShouldBeDefined()
    {
        var events = new object[]
        {
            new PlayerAttackedByZombieEvent(1, 2, BobyPart.Head),
            new PlayerDiedEvent(1),
        };

        const int expectedEventTypesCount = 2;
        events.Should().HaveCount(expectedEventTypesCount);
        events.GroupBy(e => e.GetType()).Should().HaveCount(expectedEventTypesCount);
    }
}
