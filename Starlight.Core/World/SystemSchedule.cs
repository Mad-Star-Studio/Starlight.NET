using System.Text;
using Starlight.API.World;

namespace Starlight.Core.World;

public class SystemSchedule(IEnumerable<IWorldPhase> phases, IEnumerable<ISystem> dependencies): ISystemSchedule
{
    public IEnumerable<IWorldPhase> Phases { get; } = phases;

    public IEnumerable<ISystem> Dependencies { get; } = dependencies;

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.Append("Schedule: ");
        foreach (IWorldPhase phase in Phases)
        {
            builder.Append(phase.Name);
            builder.Append(", ");
        }

        builder.Remove(builder.Length - 2, 2);
        return builder.ToString();
    }
}