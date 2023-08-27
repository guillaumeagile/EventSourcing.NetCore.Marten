using System.Data.Common;
using System.Runtime.CompilerServices;

namespace MyDotNetEventSourcedProject;

public record Player(int Id, int HealthPercent)
{
    public Player GetPlayerState(IDomainEvent[] events) => this;

    public static Player Create()
    {
        throw new NotImplementedException();
    }
}
