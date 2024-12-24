namespace Starlight.API.Registration;

public class ModListBuilder
{
    private List<Mod> Mods { get; } = new();
    private class ModList: IModList
    {
        private readonly Dictionary<Type, (Type, Func<object>)> _registeredTypes = new();
        private readonly List<Mod> _mods = [];
        public IEnumerable<Mod> Mods { get; }
        
        public ModList(List<Mod> mods)
        {
            _mods.AddRange(mods);
            // Load all registered types from mods
            foreach (var mod in mods)
            {
                foreach (var type in mod.Registry.RegisteredTypes)
                {
                    _registeredTypes[type.Key] = type.Value;
                }
            }
            Mods = _mods;
        }

        public Dictionary<Type, (Type, Func<object>)> RegisteredTypes { get; } = new();

        public bool TryGetRegisteredType<T>(out Type type, out Func<T> constructor)
        {
            if (_registeredTypes.TryGetValue(typeof(T), out var value))
            {
                type = value.Item1;
                constructor = () => (T)value.Item2();
                return true;
            }
            
            type = null!;
            constructor = null!;
            return false;
        }
    }
    
    public ModListBuilder() {}
    
    protected ModListBuilder(IEnumerable<Mod> mods)
    {
        Mods.AddRange(mods);
    }
    
    public ModListBuilder AddMod(Mod mod)
    {
        Mods.Add(mod);
        return this;
    }
    
    public ModListBuilder AddMods(IEnumerable<Mod> mods)
    {
        Mods.AddRange(mods);
        return this;
    }
    
    public IModList Build()
    {
        return new ModList(Mods);
    }
}