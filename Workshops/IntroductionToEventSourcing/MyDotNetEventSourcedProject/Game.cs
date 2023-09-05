using System.Runtime.CompilerServices;
using LanguageExt;
using LanguageExt.Sys.Test;

namespace MyDotNetEventSourcedProject;
 public enum ProgressionState
    {
        NotStarted,
        Running,
        Ended
    }
public record Game(ProgressionState progession, IEnumerable<Player> listOfPlayers)
{
    public static Game GetGame(IEnumerable<object> events) =>
        events.Aggregate(Game.Default(), Game.When);

    public static Game Default() => new(ProgressionState.NotStarted, new List<Player>() );

    public static Game When(Game game, object @event)
    {
        return @event switch
        {
            PlayerEnteredTheGame(int PlayerId) => game with  // https://www.educative.io/answers/what-is-non-destructive-mutation-in-c-sharp-90
            {
                progession = ProgressionState.Running,
                listOfPlayers =  //new []{ new Player(PlayerId, 100)}
                                 game.listOfPlayers.Append((new Player(PlayerId, 100)))
                                // game.listOfPlayers.Concat(new List<Player> { new (PlayerId, 100)})
            },
            _ => game
        };
    }
}
