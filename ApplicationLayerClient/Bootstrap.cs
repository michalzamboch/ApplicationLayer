using ApplicationLayer;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayerClient;

public static class Bootstrap
{
    public static ServiceProvider Build()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IPersonService, PersonService>();
        serviceCollection.AddSingleton<IAnotherService, AnotherService>();

        return serviceCollection.BuildServiceProvider();
    }
}