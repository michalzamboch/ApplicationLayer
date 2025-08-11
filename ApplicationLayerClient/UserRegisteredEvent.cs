using Paramore.Brighter;

public sealed class UserRegisteredEvent : Event
{
    public UserRegisteredEvent(Guid id, string username) : base(id)
    {
        Username = username;
    }

    public string Username { get; }
}

public sealed class UserUnregisteredEvent : Event
{
    public UserUnregisteredEvent(Guid id, string username) : base(id)
    {
        Username = username;
    }

    public string Username { get; }
}

public class WelcomeEmailEventHandler : IHandleRequests<UserRegisteredEvent>,  IHandleRequests<UserUnregisteredEvent>
{
    public void Handle(UserRegisteredEvent @event)
    {
        // Logic to send a welcome email to the user
        Console.WriteLine($"Sending welcome email to {@event.Username}");
    }

    public UserRegisteredEvent Fallback(UserRegisteredEvent request)
    {
        throw new NotImplementedException();
    }

    public void SetSuccessor(IHandleRequests<UserRegisteredEvent> successor)
    {
        throw new NotImplementedException();
    }

    public void DescribePath(IAmAPipelineTracer pathExplorer)
    {
        throw new NotImplementedException();
    }

    public void InitializeFromAttributeParams(params object[] initializerList)
    {
        throw new NotImplementedException();
    }

    public void AddToLifetime(IAmALifetime instanceScope)
    {
        throw new NotImplementedException();
    }

    public IRequestContext Context { get; set; }
    public HandlerName Name { get; }
    UserRegisteredEvent IHandleRequests<UserRegisteredEvent>.Handle(UserRegisteredEvent request)
    {
        throw new NotImplementedException();
    }

    public UserUnregisteredEvent Handle(UserUnregisteredEvent request)
    {
        throw new NotImplementedException();
    }

    public UserUnregisteredEvent Fallback(UserUnregisteredEvent request)
    {
        throw new NotImplementedException();
    }

    public void SetSuccessor(IHandleRequests<UserUnregisteredEvent> successor)
    {
        throw new NotImplementedException();
    }
}