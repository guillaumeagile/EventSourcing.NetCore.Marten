using System.Data.Common;
using System.Runtime.CompilerServices;

namespace MyDotNetEventSourcedProject;

public record Player(int Id, int LifePoints)
{
    public Player GetPlayerState(IDomainEvent[] events) => this;


    public Player ReveceiveAttack(int InjuryReceived, IEventListener myeventListener)
    {
        var newLifePoints = LifePoints - InjuryReceived;
        //TODO: extraire dans une fonction de décision
        if (newLifePoints== 0)
            myeventListener.PushNewEvent(new PlayerDiedEvent(Id));
        return this with { LifePoints = newLifePoints };
    }
}
