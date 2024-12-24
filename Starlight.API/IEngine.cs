using Starlight.API.Registration;

namespace Starlight.API;

/// <summary>
/// Represents the core engine of the game.
///
/// The engine is responsible for managing the game loop, modules, and other core functionality.
/// </summary>
public interface IEngine: IRegisteredType, IRegisteredTypeConstructor<IEngine>
{
    public static IEngine Current { get; set;  }
    
    /// <summary>
    /// The target frames per second of the engine. It is not guaranteed that the engine will run at this frame rate.
    /// </summary>
    public float FPS { get; set; }
    
    public void Start();

    public void Stop();

    /// <summary>
    /// Current state of the engine.
    /// </summary>
    public GameState State { get; }

    #region Events 
    public event EventHandler<GameState> StateChanged;

    #region Lifecycle events

    public event EventHandler Starting;

    public event EventHandler Started;

    public event EventHandler Stopping;

    public event EventHandler Stopped;
    
    #endregion

    #endregion

    #region Runtime
    
    protected void Initialize();
    
    protected void Update();
    
    protected void Render();
    
    protected void Shutdown();

    #endregion
    
    #region Modules
    
    public void RegisterModule(IEngineComponent component);
    
    public void UnregisterModule(IEngineComponent component);
    
    public void UnregisterModule<T>() where T : IEngineComponent;
    
    public IEngineComponent? GetModule<T>() where T : IEngineComponent;
    
    public IEnumerable<IEngineComponent> GetModules();
    
    #endregion

    public void Dispose();
}
