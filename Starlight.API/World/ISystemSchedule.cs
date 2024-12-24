namespace Starlight.API.World;

public interface ISystemSchedule
{
    public IEnumerable<IWorldPhase> Phases { get; }
    
    public IEnumerable<ISystem> Dependencies { get; }
}