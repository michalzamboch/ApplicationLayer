using Mediator;

namespace ApplicationLayer;

public sealed class PrintMessage : INotification
{
    public Guid Id { get; }
    public string Message { get; }
    
    public PrintMessage(Guid id, string message)
    {
        Id = id;
        Message = message;
    }
}

public sealed class MessagePrinter : INotificationHandler<PrintMessage>
{
    public ValueTask Handle(PrintMessage notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(" > " + notification.Message);
        return default;
    }
}