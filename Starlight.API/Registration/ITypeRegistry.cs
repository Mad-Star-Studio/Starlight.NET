namespace Starlight.API.Registration;

public interface ITypeRegistry
{
    public Dictionary<Type, (Type, Func<object>?)> RegisteredTypes { get; }
    
    public bool TryGetRegisteredType<T>(out Type type, out Func<T> constructor);
}