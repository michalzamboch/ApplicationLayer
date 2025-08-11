using ApplicationLayer;

namespace ApplicationLayerClient;

public class PipelineTest2
{
    public static async Task Execute()
    {
        var pipelineA = Pipeline.Empty
            .Use(next => async message =>
            {
                Console.WriteLine("Pipeline A" + message.Payload);
                message.Payload += " [A1]";
                await next(message);
            });

        var pipelineB = Pipeline.Empty
            .Use(next => async message =>
            {
                Console.WriteLine("Pipeline B" + message.Payload);
                message.Payload += " [B1]";
                await next(message);
            });

        var fullPipeline = pipelineA.HookInto(pipelineB);

        await fullPipeline.Handle(new Message() { Payload = "Hello World!" });
    }
}