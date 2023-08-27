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
        var player = game.GetPlayerState(1);

        player.Should().BeNone();
       }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void CreatedEventIsExisting()
    {
        events.Add(new PlayerEnteredTheArena(1));
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.Running);

    }
    /*    var player = game.GetPlayerState(1);
player.Should().BeSome();
              var expectedPlayer = new Player(1, 100);
              player.Should().Be(expectedPlayer);
 */
}
