using Starlight.API.Registration;

namespace Starlight.API.World;

public interface ISystemManager: IRegisteredType, IRegisteredTypeConstructor<ISystemManager>
{
    public void RunSystems(Arch.Core.World world, IWorldPhase phase);
    
    #region System Management

    public IEnumerable<ISystem> Systems { get; }
    
    public IEnumerable<ISystem> GetSystemsByPhase(IWorldPhase phase);
    
    public IEnumerable<ISystem> GetSystemsByType<T>(bool includeSubTypes) where T : ISystem;
    
    public IEnumerable<ISystem> GetSystemsByType<T>(bool includeSubTypes, IWorldPhase phase) where T : ISystem;
    
    public IEnumerable<ISystem> GetSystemsByType(Type type, bool includeSubTypes);
    
    public IEnumerable<ISystem> GetSystemsByType(Type type, bool includeSubTypes, IWorldPhase phase);
    
    public IEnumerable<ISystem> GetSystemsBySchedule(ISystemSchedule schedule);
    
    public IEnumerable<ISystem> GetSystemsBySchedule(ISystemSchedule schedule, IWorldPhase phase);
    
    public void RegisterSystem(ISystem system, ISystemSchedule schedule);
    
    public void UnregisterSystem(ISystem system);

    #endregion
}