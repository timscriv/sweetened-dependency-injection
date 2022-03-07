namespace Sugar.Api;

// [Injectable(ServiceLifetime.Singleton)]
// [Injectable(ServiceLifetime.Transient)]
// [Injectable(ServiceLifetime.Scoped)]
[Injectable] // Defaults to scoped
public class GreeterService : IGreeterService
{
    public string Greet()
    {
        return "Hello World!";
    }
}