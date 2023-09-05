using System.Data.Common;
using System.Runtime.CompilerServices;

namespace MyDotNetEventSourcedProject;

public record Player(int Id, int LifePoints)
{
    public Player GetPlayerState(IDomainEvent[] events) => this;


    public Player ReveceiveAttack(int InjuryReceived)
    {
        return this with { LifePoints = LifePoints - InjuryReceived };
    }
}
