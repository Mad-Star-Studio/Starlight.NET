using Arch.Core;
using Starlight.API;
using Starlight.API.Registration;

namespace Starlight.Core;

[AutoRegisterCreation]
public class Engine : IEngine
{
    private readonly List<IEngineComponent> _modules = [];

    public float FPS { get; set; } = 60;

    public void Start()
    {
        Console.Out.WriteLine("Starting engine");
    }

    public void Stop()
    {
        
    }

    public GameState State { get; }
    public event EventHandler<GameState>? StateChanged;
    public event EventHandler? Starting;
    public event EventHandler? Started;
    public event EventHandler? Stopping;
    public event EventHandler? Stopped;
    
    public void Initialize()
    {
        
    }

    public void Update()
    {
        
    }

    public void Render()
    {
        
    }

    public void Shutdown()
    {
        
    }

    public void RegisterModule(IEngineComponent component)
    {
        _modules.Add(component);
    }

    public void UnregisterModule(IEngineComponent component)
    {
        _modules.Remove(component);
    }

    public void UnregisterModule<T>() where T : IEngineComponent
    {
        _modules.RemoveAll(x => x.GetType() == typeof(T));
    }

    public IEngineComponent? GetModule<T>() where T : IEngineComponent
    {
        return _modules.FirstOrDefault(x => x != null && x.GetType() == typeof(T), null);
    }

    public IEnumerable<IEngineComponent> GetModules()
    {
        return _modules;
    }

    public void Dispose()
    {
        
    }
}
