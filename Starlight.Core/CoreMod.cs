using Starlight.API;
using Starlight.API.Registration;

namespace Starlight.Core;

public class CoreMod: Mod
{
    public override void Initialize()
    {
        Name = "Starlight Core Engine Library";
        Description = "Provides the core engine functionality for Starlight";
        Author = "TheFelidae and contributors";
        Version = Assembly.GetName().Version!;
    }

    public override void EngineRegister(IEngine engine)
    {
    }

    public override void EngineUnregister(IEngine engine)
    {
    }
}