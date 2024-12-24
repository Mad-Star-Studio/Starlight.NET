using System.Reflection;
using Starlight.API.Registration;

namespace Starlight.Loader;

public class Loader
{
    private List<Assembly> _assemblies = [];
    
    
    public Loader()
    {
        
    }
    
    private Loader(List<Assembly> assemblies)
    {
        _assemblies = assemblies;
    }
    
    public Loader AddAssembly(string path)
    {
        _assemblies.Add(Assembly.LoadFrom(path));
        return new Loader(_assemblies);
    }
    
    public void Load()
    {
        _assemblies.Add(Assembly.GetExecutingAssembly());
        
        // Deduplicate assemblies
        _assemblies = _assemblies.Distinct().ToList();

        var builder = new ModListBuilder();
        
        foreach (var mods in _assemblies.Select(assembly => Mod.ModsFromAssembly(assembly)))
        {
            builder.AddMods(mods);
        }
        
        var modList = builder.Build();
        
        foreach (var mod in modList.Mods)
        {
            mod.Initialize();
        }
        
        Mod.ActiveModList = modList;
    }
}