using Microsoft.Extensions.DependencyModel;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoRegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromDependencyContext(DependencyContext.Default)
            .AddClasses(classes => classes.AssignableTo<ISingleton>())
            .AsSelfWithInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.AssignableTo<IScoped>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<ITransient>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        return services;
    }
}

public interface ISingleton
{
}

public interface IScoped
{
}

public interface ITransient
{
}
