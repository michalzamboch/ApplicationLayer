using Microsoft.Extensions.DependencyInjection;
using Mediator;
using ApplicationLayer;

var services = new ServiceCollection();
services.AddMediator((MediatorOptions options) => options.Assemblies = []);
await using var serviceProvider = services.BuildServiceProvider();

var mediator = serviceProvider.GetRequiredService<IMediator>();
var ping = new Ping(Guid.NewGuid());
var pong = await mediator.Send(ping);

Console.WriteLine(ping.Id);
Console.WriteLine(pong.Id);
Console.WriteLine(pong.Id == ping.Id);

await mediator.Publish(new PrintMessage(Guid.NewGuid(), "Hello world"));