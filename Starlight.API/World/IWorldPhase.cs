namespace Starlight.API.World;

public interface IWorldPhase
{
    public string Name { get; }
    
    public bool MultiThreaded { get; }
}