namespace Starlight.API.World;

/// <summary>
/// A system is a component of a game that is responsible for a specific task in the world.
/// </summary>
public interface ISystem
{
    public void Run(Arch.Core.World world);
}