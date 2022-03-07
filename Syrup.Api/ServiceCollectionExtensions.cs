using Microsoft.Extensions.DependencyModel;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoRegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default)
            .AddClasses(classes => classes.WithAttribute<ScopedAttribute>())
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.WithAttribute<SingletonAttribute>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.WithAttribute<TransientAttribute>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ScopedAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class SingletonAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TransientAttribute : Attribute
{
}