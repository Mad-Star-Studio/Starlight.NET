using Starlight.API.Registration;
using Starlight.API.World;

namespace Starlight.Core.World;

public class SystemScheduleBuilder: ISystemScheduleBuilder
{
    private readonly List<IWorldPhase> _phases = [];
    private readonly List<ISystem> _dependencies = [];

    public SystemScheduleBuilder() {}
    
    private SystemScheduleBuilder(IEnumerable<IWorldPhase> phases, IEnumerable<ISystem> dependencies)
    {
        _phases.AddRange(phases);
        _dependencies.AddRange(dependencies);
    }
    
    public ISystemScheduleBuilder AddDependency(ISystem system)
    {
        _dependencies.Add(system);
        return new SystemScheduleBuilder(_phases, _dependencies);
    }
    
    public ISystemScheduleBuilder AddDependencies(IEnumerable<ISystem> systems)
    {
        _dependencies.AddRange(systems);
        return new SystemScheduleBuilder(_phases, _dependencies);
    }

    public ISystemScheduleBuilder AddPhase(IWorldPhase phase)
    {
        _phases.Add(phase);
        return new SystemScheduleBuilder(_phases, _dependencies);
    }
    
    public ISystemScheduleBuilder AddPhases(IEnumerable<IWorldPhase> phases)
    {
        _phases.AddRange(phases);
        return new SystemScheduleBuilder(_phases, _dependencies);
    }
    
    public ISystemSchedule Build()
    {
        return new SystemSchedule(_phases, _dependencies);
    }
}