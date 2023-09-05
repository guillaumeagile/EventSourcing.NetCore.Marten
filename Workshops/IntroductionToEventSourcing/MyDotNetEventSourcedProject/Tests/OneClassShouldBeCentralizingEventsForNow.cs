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

    [Fact]
    [Trait("Category", "SkipCI")]
    public void OnePlayerInTheGameIsWounded()
    {
        events.Add(new PlayerEnteredTheGame(1));
        events.Add(new PlayerIsAttacked(1, 68));
        var game = Game.GetGame(events);

        game.listOfPlayers.First().LifePoints.Should().Be(32);
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void OnePlayerOutOfTwoInTheGameIsWounded()
    {
        events.Add(new PlayerEnteredTheGame(1));
        events.Add(new PlayerEnteredTheGame(2));

        events.Add(new PlayerIsAttacked(1, 50));
        events.Add(new PlayerIsAttacked(2, 10));

        var game = Game.GetGame(events);

        game.listOfPlayers.First().Id.Should().Be(1);
        game.listOfPlayers.First().LifePoints.Should().Be(50);
        game.listOfPlayers.Last().LifePoints.Should().Be(90);
    }

    [Fact]
    [Trait("Category", "SkipCI")]
    public void OnePlayerOutOfTwoInTheGameIsWoundedButOrderOfEventChangeTheOrderInTheListOfPlayers()
    {
        events.Add(new PlayerEnteredTheGame(1));
        events.Add(new PlayerEnteredTheGame(2));

        events.Add(new PlayerIsAttacked(2, 10));
        events.Add(new PlayerIsAttacked(1, 50));

        var game = Game.GetGame(events);

        game.listOfPlayers.First().Id.Should().Be(2);
        game.listOfPlayers.First().LifePoints.Should().Be(90);
        // TEST DE CONSOLIDATION: pour nous, ca ne pose pas de probleme
    }




    /*    var player = game.GetPlayerState(1);
player.Should().BeSome();
              var expectedPlayer = new Player(1, 100);
              player.Should().Be(expectedPlayer);
 */
}

