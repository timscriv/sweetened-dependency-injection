namespace Honey.Api;

// [RegisterAsSingleton]
// [RegisterAsTransient]
[RegisterAsScoped]
public class GreeterService : IGreeterService
{
    public string Greet()
    {
        return "Hello World!";
    }
}