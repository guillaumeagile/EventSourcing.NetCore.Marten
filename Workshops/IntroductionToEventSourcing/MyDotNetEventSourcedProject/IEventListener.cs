namespace MyDotNetEventSourcedProject;

public interface IEventListener
{
    IEnumerable<IDomainEvent> Events { get; }

    void PushNewEvent(IDomainEvent @event);
}
