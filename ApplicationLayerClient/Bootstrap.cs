using ApplicationLayer;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayerClient;

public static class Bootstrap
{
    public static ServiceProvider Build()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IPersonService, PersonService>();
        services.AddSingleton<IAnotherService, AnotherService>();

        return services.BuildServiceProvider();
    }
}