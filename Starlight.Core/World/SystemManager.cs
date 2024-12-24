using Starlight.API.World;

namespace Starlight.Core.World;

public class SystemManager: ISystemManager
{
    private Dictionary<ISystemSchedule, ISystem> _systems = [];
    
    public SystemManager()
    {
        
    }

    #region ISystemManager Implementation

    public void RunSystems(Arch.Core.World world, IWorldPhase phase)
    {
        
    }

    public IEnumerable<ISystem> Systems => _systems.Values;
    public IEnumerable<ISystem> GetSystemsByPhase(IWorldPhase phase)
    {
        return _systems.Where(system => system.Key.Phases.Contains(phase))
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsByType<T>(bool includeSubTypes) where T : ISystem
    {
        return _systems.Where(system => system.Value is T)
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsByType<T>(bool includeSubTypes, IWorldPhase phase) where T : ISystem
    {
        return _systems.Where(system => system.Value is T && system.Key.Phases.Contains(phase))
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsByType(Type type, bool includeSubTypes)
    {
        return _systems.Where(system => type.IsAssignableFrom(system.Value.GetType()))
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsByType(Type type, bool includeSubTypes, IWorldPhase phase)
    {
        return _systems.Where(system => type.IsAssignableFrom(system.Value.GetType()) && system.Key.Phases.Contains(phase))
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsBySchedule(ISystemSchedule schedule)
    {
        return _systems.Where(system => system.Key == schedule)
                .Select(system => system.Value);
    }

    public IEnumerable<ISystem> GetSystemsBySchedule(ISystemSchedule schedule, IWorldPhase phase)
    {
        return _systems.Where(system => system.Key == schedule && system.Key.Phases.Contains(phase))
                .Select(system => system.Value);
    }

    public void RegisterSystem(ISystem system, ISystemSchedule schedule)
    {
        _systems[schedule] = system;
    }

    public void UnregisterSystem(ISystem system)
    {
        try
        {
            var schedule = _systems
                .First(x => x.Value == system);
            _systems.Remove(schedule.Key);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("System not found in manager.");
        }
    }
    
    #endregion
}