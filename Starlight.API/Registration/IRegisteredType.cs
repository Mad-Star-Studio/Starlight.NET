namespace Starlight.API.Registration;

public interface IRegisteredType
{
}

public interface IRegisteredTypeConstructor<T>
{
    public static Func<T> Create => IRegisteredTypeMetadata<T>.Create;
}

public interface IRegisteredTypeMetadata<T>
{
    public static Func<T> Create { get; set; } = () =>
    {
        if (Mod.ActiveModList is null)
        {
            throw new InvalidOperationException("No active mod list");
        }
        foreach (var mod in Mod.ActiveModList.Mods)
        {
            if (mod.Registry.TryGetRegisteredType<T>(out var type, out var constructor))
            {
                return constructor();
            }
        }
        
        throw new NotImplementedException($"No registered type found for {typeof(T).FullName}");
    };
}