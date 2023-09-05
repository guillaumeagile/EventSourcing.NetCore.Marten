using FluentAssertions;
using MediatR;
using FluentAssertions.LanguageExt;
using Xunit;

namespace MyDotNetEventSourcedProject;

public class OneClassShouldBeCentralizingEventsForNow
{
    List< IDomainEvent> events;
    public OneClassShouldBeCentralizingEventsForNow()
    {
        events = new ();
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void WhileNoEvents_BeginStateIsS()
    {
        var game = Game.GetGame(events);
        game.progession.Should().Be(ProgressionState.NotStarted);

    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void CreatedEventIsExisting()
    {
        events.Add(new PlayerEnteredTheGame(1));
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.Running);
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void OneEventsForOnePlayerInTheGame()
    {
        events.Add(new PlayerEnteredTheGame(1));
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.Running);
        game.listOfPlayers.Count().Should().Be(1);
    }


    [Fact]
    [Trait("Category", "SkipCI")]
    public void TwoEventsForTwoPlayersInTheGame()
    {
        events.Add(new PlayerEnteredTheGame(1));
        events.Add(new PlayerEnteredTheGame(2));
        var game = Game.GetGame(events);

        game.progession.Should().Be(ProgressionState.Running);
        game.listOfPlayers.Count().Should().Be(2);
    }





    /*    var player = game.GetPlayerState(1);
player.Should().BeSome();
              var expectedPlayer = new Player(1, 100);
              player.Should().Be(expectedPlayer);
 */
}
