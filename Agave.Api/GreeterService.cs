namespace Agave.Api;

public class GreeterService : IGreeterService, IScoped // ISingleton ITransient
{
    public string Greet()
    {
        return "Hello World!";
    }
}