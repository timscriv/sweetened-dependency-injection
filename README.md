# sweetened-dependency-injection

A few different ways to do DI to make life a bit easier. This is to get it on paper and see which implementation I like best.

All these services are .Net 6 Minimal APIs that have one `/` route and are injected with one service `IGreeterService` which returns `Hello World!`. 
This is a terrible case for anything more than the unsweet version but as service dependencies grow `services.AddWhatever` becomes a graveyard.

## Unsweet

This is the basic, standard DI. `services.AddSomeStuff<>()` 

## Agave 

This implementation adds another interface to the concrete class of `IScoped/ISingleton/ITransient` to define
services that should be registered and their lifetimes.

### Example

```c#
public class GreeterService : IGreeterService, IScoped
```

## Honey

This implementation uses an attribute on the concrete class of `RegisterAsSingleton/RegisterAsTransient/RegisterAsScoped`
to define services that should be registered and their lifetimes.

### Example

```c#
[RegisterAsScoped]
public class GreeterService : IGreeterService
```

## Sugar

This implementation uses and attribute on the concrete class if `Injectable` to define services that should be registers,
and takes in an argument to define their lifetime `ServiceLifetime.Scoped`. Very similar to angular services.

### Example

```c#
[Injectable(ServiceLifetime.Scoped)]
public class GreeterService : IGreeterService
```

## Syrup

This implementation uses an attribute on the concrete class of `Singleton/Transient/Scoped`
to define services that should be registered and their lifetimes. Very similar to honey with different words.

### Example

```c#
[Scoped]
public class GreeterService : IGreeterService
```
