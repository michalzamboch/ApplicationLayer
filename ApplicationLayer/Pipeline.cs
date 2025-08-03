namespace ApplicationLayer;

public class Pipeline
{
    private readonly Func<Message, Task> _handler;

    public Pipeline(Func<Message, Task> handler)
    {
        _handler = handler;
    }

    public Task Handle(Message message) => _handler(message);

    // Adds a new middleware to the pipeline
    public Pipeline Use(Func<Func<Message, Task>, Func<Message, Task>> middleware)
    {
        return new Pipeline(middleware(_handler));
    }

    // Hooks another pipeline (calls next after current)
    public Pipeline HookInto(Pipeline next)
    {
        return Use(nextMiddleware => async message =>
        {
            await _handler(message);         // Run current pipeline
            await next.Handle(message);      // Pass message to next pipeline
        });
    }

    // Static helper to create a terminal pipeline
    public static Pipeline Empty => new Pipeline(_ => Task.CompletedTask);
}