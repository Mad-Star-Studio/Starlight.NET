using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Starlight.API.Registration;

public class TypeRegistry: ITypeRegistry
{
    public Dictionary<Type, (Type, Func<object>?)> RegisteredTypes { get; } = new();
    
    public bool TryGetRegisteredType<T>(out Type type, out Func<T> constructor)
    {
        if (RegisteredTypes.TryGetValue(typeof(T), out var value))
        {
            type = value.Item1;
            if (value.Item2 is null)
            {
                constructor = null!;
            }
            else 
                constructor = () => (T)value.Item2();
            return true;
        }
        
        type = null!;
        constructor = null!;
        return false;
    }

    public TypeRegistry(Assembly assembly)
    {
        // Identify types deriving from IRegisteredType
        var types = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IRegisteredType)));
        
        // Register each type
        foreach (var type in types)
        {
            Func<object>? constructor = null;
            
            // Identify if AutoRegisterCreation attribute is present
            var attribute = type.GetCustomAttribute<AutoRegisterCreationAttribute>();
            // If so, dynamically create a constructor
            if (attribute != null)
            {
                var constructorMethod = new DynamicMethod(
                    $"Create{type.Name}",
                    type,
                    Type.EmptyTypes,
                    type.Module,
                    true
                );
                
                var il = constructorMethod.GetILGenerator();
                il.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
                il.Emit(OpCodes.Ret);
                
                constructor = (Func<object>)constructorMethod.CreateDelegate(typeof(Func<object>));
            }
            
            // Get the interface types
            // - must descend from IRegisteredType
            // - must not be IRegisteredType itself
            var interfaces = type.GetInterfaces()
                .Where(i => i != typeof(IRegisteredType) && i.GetInterfaces().Contains(typeof(IRegisteredType)));
            foreach (var iface in interfaces)
            {
                RegisterType(iface, type, constructor);
            }
        }
    }
    
    public void RegisterType<T>(Type implType, Func<T> create) where T : IRegisteredType
    {
        RegisterType(typeof(T), implType, () => create());
    }
    
    public void RegisterType(Type type, Type implType, Func<object> create)
    {
        RegisteredTypes.Add(type, (implType, create));
    }

    public T Create<T>()
    {
        #if DEBUG
        var type = typeof(T);
        if (!RegisteredTypes.ContainsKey(type))
        {
            throw new InvalidOperationException($"Type {type} is not registered.");
        }
        #endif
        
        var constructor = RegisteredTypes[type].Item2;
        return (T)constructor();
    }
}