using FluentAssertions;
using MediatR;
using FluentAssertions.LanguageExt;
using Xunit;

namespace MyDotNetEventSourcedProject;

public class OneClassShouldBeCentralizingEventsForNow
{
    IDomainEvent[] events;
    public OneClassShouldBeCentralizingEventsForNow()
    {
        events = new IDomainEvent[]
        {
          //  new PlayerEnteredTheArena(1),
          //  new PlayerAttackedByZombieEvent(1, 2, BobyPart.Head),
          //  new PlayerDiedEvent(1),
        };
    }



    [Fact]
    [Trait("Category", "SkipCI")]
    public void WhileNoEvents()
    {
        var game = new Game(events);

        var player = game.GetPlayerState(1);

        player.Should().BeNone();
       }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void CreatedEventIsExisting()
    {
        var game = new Game(events);

        var player = game.GetPlayerState(1);

        player.Should().BeSome();
        var expectedPlayer = new Player(1, 100);
        player.Should().Be(expectedPlayer);

    }
}
