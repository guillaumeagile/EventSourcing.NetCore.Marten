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
                listOfPlayers =  game.listOfPlayers.Append((new Player(PlayerId, 100)))
            },
            PlayerIsAttacked(int PlayerId, int InjuryReceived) => game with
            {
                listOfPlayers = ListAfterOnePlayerHasBeenAttacked(game, PlayerId, InjuryReceived)
            },
            _ => game
        };
    }

    private static IEnumerable<Player> ListAfterOnePlayerHasBeenAttacked(Game game, int playerId, int injuryReceived)
    {
        var concernedPlayer = game.listOfPlayers.Filter(p => p.Id == playerId).FirstOrDefault();
        var listOfPlayers = game.listOfPlayers.Filter(p => p.Id != playerId).ToList();

        // à remplacer par le pattern FAN OUT (distribution d'evenements aux entités concernées)
        listOfPlayers.Add(concernedPlayer.ReveceiveAttack(injuryReceived));

        return listOfPlayers;
    }
}
