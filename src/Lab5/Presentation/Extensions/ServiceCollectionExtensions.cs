using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios.Models;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection collection)
    {
        collection.AddScoped<StartScenario>();
        collection.AddScoped<AccountLoginScenario>();

        return collection;
    }
}
