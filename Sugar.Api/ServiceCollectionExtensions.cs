using Microsoft.Extensions.DependencyModel;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoRegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default)
            .AddClasses(classes => classes.WithAttribute<InjectableAttribute>(c => c.Lifetime == ServiceLifetime.Singleton))
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.WithAttribute<InjectableAttribute>(c => c.Lifetime == ServiceLifetime.Scoped))
            .AsSelfWithInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.WithAttribute<InjectableAttribute>(c => c.Lifetime == ServiceLifetime.Transient))
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

public class InjectableAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }
    public InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Scoped)
    {
        Lifetime = lifeTime;
    }
}