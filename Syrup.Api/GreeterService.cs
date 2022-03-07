namespace Syrup.Api;

// [Singleton]
// [Transient]
[Scoped]
public class GreeterService : IGreeterService
{
    public string Greet()
    {
        return "Hello World!";
    }
}