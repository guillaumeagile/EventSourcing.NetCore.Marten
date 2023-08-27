using LanguageExt;
using LanguageExt.Sys.Test;

namespace MyDotNetEventSourcedProject;

public class Game
{
    public Game(IEnumerable<IDomainEvent> domainEvents)
    {

    }

    public Option<Player> GetPlayerState(int i)
    {
       return Option<Player>.None;
    }
}
