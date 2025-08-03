using ApplicationLayer;
using ApplicationLayerClient;
using Microsoft.Extensions.DependencyInjection;

using var provider = Bootstrap.Build();

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