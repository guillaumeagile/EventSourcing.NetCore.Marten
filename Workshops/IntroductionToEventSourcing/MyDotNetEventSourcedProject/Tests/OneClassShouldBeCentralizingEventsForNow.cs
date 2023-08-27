using FluentAssertions;
using MediatR;
using FluentAssertions.LanguageExt;
using Xunit;

namespace MyDotNetEventSourcedProject;

public class OneClassShouldBeCentralizingEventsForNow
{
    List< IDomainEvent> events = new ();
    public OneClassShouldBeCentralizingEventsForNow()
    {
        //  new PlayerEnteredTheArena(1),
          //  new PlayerAttackedByZombieEvent(1, 2, BobyPart.Head),
          //  new PlayerDiedEvent(1),
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void WhileNoEvents()
    {
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.NotStarted);
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void CreatedEventIsExisting()
    {
        events.Add(new PlayerEnteredTheArena(1));
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.Running);

    }

}
