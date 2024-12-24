using Starlight.API.Registration;

namespace Starlight.API.World;

public interface ISystemScheduleBuilder: IRegisteredType, IRegisteredTypeConstructor<ISystemScheduleBuilder>
{
    public ISystemSchedule Build();

    #region 
    
    public ISystemScheduleBuilder AddDependency(ISystem system);
    
    public ISystemScheduleBuilder AddDependencies(IEnumerable<ISystem> systems);
    
    public ISystemScheduleBuilder AddPhase(IWorldPhase phase);
    
    public ISystemScheduleBuilder AddPhases(IEnumerable<IWorldPhase> phases);
    
    #endregion
}