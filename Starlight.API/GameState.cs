namespace Starlight.API;

/// <summary>
/// Represents the state of the engine.
/// </summary>
public enum GameState
{
    /// <summary>
    /// The engine is stopped.
    /// Game logic is not able to be executed in this state.
    /// </summary>
    Stopped,
    /// <summary>
    /// The engine is running
    /// Game logic is able to be executed in this state.
    /// </summary>
    Running,
    /// <summary>
    /// The engine has failed to run correctly due to a fault.
    /// Game logic is not able to be executed in this state.
    /// </summary>
    Failed
}
