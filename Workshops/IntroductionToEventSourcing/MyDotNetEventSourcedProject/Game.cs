using System.Runtime.CompilerServices;
using LanguageExt;
using LanguageExt.Sys.Test;

namespace MyDotNetEventSourcedProject;

public class Game
{

    public Game() : this (new List<Player>())
    {
    }
    public Game(IEnumerable<Player> listOfPlayers)
    {
    }

    public static Game GetGame(IEnumerable<object> events) =>
        events.Aggregate(Game.Default(), Game.When);

    public static Game Default() => new ( );

    public static Game When(Game shoppingCart, object @event)
    {
        return @event switch
        {
            _ => shoppingCart
        };
    }

    public Option<Player> GetPlayerState(int i)
    {
       return Option<Player>.None;
    }



}
