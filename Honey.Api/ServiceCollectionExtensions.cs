using Microsoft.Extensions.DependencyModel;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoRegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default)
            .AddClasses(classes => classes.WithAttribute<RegisterAsSingletonAttribute>())
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.WithAttribute<RegisterAsScopedAttribute>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.WithAttribute<RegisterAsTransientAttribute>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class RegisterAsScopedAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class RegisterAsSingletonAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class RegisterAsTransientAttribute : Attribute
{
}