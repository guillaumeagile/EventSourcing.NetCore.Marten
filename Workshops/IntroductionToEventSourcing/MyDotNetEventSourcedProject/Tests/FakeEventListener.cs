namespace MyDotNetEventSourcedProject;

public class FakeEventListener: IEventListener
{
    private IList<IDomainEvent> _events;

    public FakeEventListener()
    {
        _events = new List<IDomainEvent>();
    }

    public IEnumerable<IDomainEvent> Events
    {
        get => _events;
    }

    public void PushNewEvent(IDomainEvent @event)
    {
        _events.Add(@event);
    }
}
