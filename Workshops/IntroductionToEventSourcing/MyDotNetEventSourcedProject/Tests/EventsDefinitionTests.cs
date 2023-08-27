using FluentAssertions;
using MediatR;
using Xunit;

namespace MyDotNetEventSourcedProject;

public class EventsDefinitionTests
{
    IDomainEvent[] events;
    public EventsDefinitionTests()
    {
        events = new IDomainEvent[]
        {
            new PlayerEnteredTheArena(1),
            new PlayerAttackedByZombieEvent(1, 2, BobyPart.Head),
            new PlayerDiedEvent(1),
        };
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void AllEventTypes_ShouldBeDefined()
    {
        const int expectedEventTypesCount = 3;
        events.Should().HaveCount(expectedEventTypesCount);
        events.GroupBy(e => e.GetType()).Should().HaveCount(expectedEventTypesCount);
    }

}
