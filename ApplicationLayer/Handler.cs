using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace ApplicationLayer;

public interface IAsyncHandler
{
    Task Handle(Message message);
}


public interface IBaseHandler
{
    void Handle(Message message);
    void AddHandler(IHandler handler);
}

public interface IHandler : IBaseHandler
{
    void RemoveHandler(IHandler handler);
    void ClearHandlers();
}

public abstract class AbstractHandler : IHandler
{
    protected readonly List<IHandler> handlers = [];
    
    public void AddHandler(IHandler handler)
    {
        handlers.Add(handler);
    }

    public void RemoveHandler(IHandler handler)
    {
        throw new NotImplementedException();
    }

    public virtual void Handle(Message message)
    {
        foreach (var handler in handlers)
        {
            handler.Handle(message);
        }
    }

    public void ClearHandlers()
    {
        handlers.Clear();
    }
}


public sealed class StrongHandler : IHandler
{
    private readonly List<IHandler> handlers = [];

    public void Handle(Message message)
    {
        foreach (var handler in handlers)
        {
            handler.Handle(message);
        }
    }
    
    public void AddHandler(IHandler handler)
    {
        handlers.Add(handler);
    }

    public void RemoveHandler(IHandler handler)
    {
        handlers.Remove(handler);
    }

    public void ClearHandlers()
    {
        handlers.Clear();
    }
}
