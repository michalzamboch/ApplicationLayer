namespace ApplicationLayer;

public sealed class Person : IHandler
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Age { get; set; }

    private readonly List<IHandler> handlers = [];

    public void AddHandler(IHandler handler)
    {
        handlers.Add(handler);
    }

    public void RemoveHandler(IHandler handler)
    {
        throw new NotImplementedException();
    }

    public void Handle(Message message)
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

public sealed class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}