using System.Reflection;

namespace Starlight.API.Registration;

/// <summary>
/// Represents a mod that can be loaded into the game engine.
///
/// Mods are responsible for adding and orchestrating new features to the game engine.
/// </summary>
public abstract class Mod: IRegisteredType
{
    #region Metadata
    
    public Assembly Assembly => GetType().Assembly;

    public TypeRegistry Registry;
    
    public int Priority = 0;

    public string Name { get; set; } = "Unnamed Mod";

    public string Description { get; set; } = "No description provided.";
    
    public string Author { get; set; } = "Unknown";
    
    public Version Version { get; set; } = new(0, 0, 0, 0);
    
    #endregion
    public Mod()
    {
        Registry = new TypeRegistry(Assembly);
    }
    
    #region Registration
    
    public static IModList ActiveModList { get; set; } = null!;
    public static List<Mod> ModsFromAssembly(Assembly assembly)
    {
        var mods = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Mod)))
            .Select(t => (Mod) Activator.CreateInstance(t)!)
            .ToList();
        
        // Extract the TypeRegistry from each mod
        foreach (var mod in mods)
        {
            mod.Registry = new TypeRegistry(mod.Assembly);
        }
        
        return mods;
    }
    
    #endregion
    
    #region Lifecycle
    
    public virtual void Initialize() {}
    
    public virtual void Shutdown() {}
    
    public virtual void EngineRegister(IEngine engine) {}
    
    public virtual void Update() {}
    
    public virtual void Render() {}
    
    public virtual void EngineUnregister(IEngine engine) {}
    
    #endregion
}