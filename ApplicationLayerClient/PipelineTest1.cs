using ApplicationLayer;

namespace ApplicationLayerClient;

public class PipelineTest1
{
    public static async Task Run()
    {
        var pipelineA = Pipeline.Empty
            .Use(next => async message =>
            {
                Console.WriteLine("Pipeline A - Step 1: " + message.Payload);
                message.Payload += " [A1]";
                await next(message);
            })
            .Use(next => async message =>
            {
                Console.WriteLine("Pipeline A - Step 2: " + message.Payload);
                message.Payload += " [A2]";
                await next(message);
            });

        var pipelineB = Pipeline.Empty
            .Use(next => async message =>
            {
                Console.WriteLine("Pipeline B - Final handler: " + message.Payload);
                await next(message);
            });

        var fullPipeline = pipelineA.HookInto(pipelineB);

        var message = new Message { Payload = "Hello" };
        await fullPipeline.Handle(message);

        Console.WriteLine("Final Message: " + message.Payload);
    }
}