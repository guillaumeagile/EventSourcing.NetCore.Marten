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
            PlayerEnteredTheArena(int PlayerId) => game with
            {
                progession = ProgressionState.Running
            },
            _ => game
        };
    }

    public Option<Player> GetPlayerState(int i)
    {
        return Option<Player>.None;
    }
}
